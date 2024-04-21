using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using static MemberShipManagement_CleanArchitecture.Domain.PackageEntity.Package;

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



        public async Task HandleDuePayments()
        {
            var dueMemberPackages = await _membershipRepository.GetDueMemberPackagesAsync();

            foreach (var membership in dueMemberPackages)
            {
                var duePayment = new Domain.DuePaymentEntity.DuePayment();
                decimal dueAmount = CalculateDueAmount(membership);
                DateTime dueDate = DateTime.Now;
                duePayment.AddDue(membership.MembershipId, dueDate, dueAmount);
                ExtendMemberPackageEndDate(membership, duePayment);
                await _context.DuePayments.AddAsync(duePayment);
            }

            await _context.SaveChangesAsync();
        }

        private decimal CalculateDueAmount(Domain.MembershipEntity.Membership membership)
        {
            var package = membership.Package;
            decimal dueAmount = 0;

            if (package.PackageType == "Daily" || package.PackageType == "Monthly")
            {
                dueAmount = membership.InstallmentAmount * 0.05m;
            }

            return dueAmount;
        }

        private void ExtendMemberPackageEndDate(Domain.MembershipEntity.Membership membership, Domain.DuePaymentEntity.DuePayment duePayment)
        {
            var package = membership.Package;
            if (package.PackageType == "Daily")
            {
                membership.DueDateCalculate(membership.EndDate.Value.AddDays(1));
            }
            else if (package.PackageType == "Monthly")
            {
                membership.DueDateCalculate(membership.EndDate.Value.AddMonths(1));
            }
        }
    }
}
