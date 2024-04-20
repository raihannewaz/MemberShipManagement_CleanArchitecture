using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DuePayment
{
    internal class DuePaymentRepository : IDuePaymentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMembershipRepository _membershipRepository;

        public DuePaymentRepository(ApplicationDbContext dbContext, IMembershipRepository membership)
        {
            _context = dbContext;
            _membershipRepository = membership;
           
        }

        public async Task HandleDuePayments(Domain.DuePaymentEntity.DuePayment duePayment)
        {
            var dueMemberPackages = await _membershipRepository.GetDueMemberPackagesAsync();

            foreach (var membership in dueMemberPackages)
            {

                decimal dueAmount = CalculateDueAmount(membership);
                DateTime dueDate = membership.EndDate.Value.AddDays(1);
                duePayment.AddDue(membership.MembershipId, dueDate, dueAmount);
                ExtendMemberPackageEndDate(membership, duePayment);
                await _context.DuePayments.AddAsync(duePayment);
            }
        }



        private decimal CalculateDueAmount(Domain.MembershipEntity.Membership membership)
        {

            var package = membership.Package;
            decimal dueAmount = 0;

            if (package.PackageType == "daily")
            {
                dueAmount = Convert.ToDecimal(membership.InstallmentAmount * 0.05m);
            }
            else if (package.PackageType == "monthly")
            {
                if (DateTime.Now.Month != membership.EndDate.Value.Month)
                {
                    dueAmount = Convert.ToDecimal(membership.InstallmentAmount * 0.05m);
                }
            }

            return dueAmount;
        }



        private void ExtendMemberPackageEndDate(Domain.MembershipEntity.Membership membership, Domain.DuePaymentEntity.DuePayment duePayment)
        {
            var package = membership.Package;
            if (package.PackageType == "daily")
            {
                int daysMissed = (int)(DateTime.Now - membership.EndDate).Value.TotalDays;
                DateTime a = membership.EndDate.Value.AddDays(daysMissed);
                membership.DueDateCalculate(a);
            }
            else if (package.PackageType == "monthly")
            {
                DateTime a = membership.EndDate.Value.AddMonths(1);
                membership.DueDateCalculate(a);

            }
        }
    }
}
