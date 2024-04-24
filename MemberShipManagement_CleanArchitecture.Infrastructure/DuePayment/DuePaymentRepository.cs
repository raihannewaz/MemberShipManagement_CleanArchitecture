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
using Microsoft.EntityFrameworkCore;
using Dapper;
using MemberShipManagement_CleanArchitecture.Application.Services;

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

        public async Task DeleteAsync(Domain.DuePaymentEntity.DuePayment duePayment)
        {
             _context.DuePayments.Remove(duePayment);
        }

        public async Task<Domain.DuePaymentEntity.DuePayment> GetById(int a)
        {
            return await _context.DuePayments.FirstOrDefaultAsync(d => d.MembershipId == a);
        }

       



        //public async Task<IEnumerable<Domain.DuePaymentEntity.DuePayment>> GetDuesById(string a)
        //{
        //    using (var conn = _dapperDbContext.CreateConnection())
        //    {
        //        var result = await conn.QueryMultipleAsync(a);

        //        var dues = await result.ReadAsync<Domain.DuePaymentEntity.DuePayment>();
        //        var memberships = await result.ReadAsync<Domain.MembershipEntity.Membership>();
        //        var members = await result.ReadAsync<Domain.MemberEntity.Member>();
        //        var packs = await result.ReadAsync<Domain.PackageEntity.Package>();

        //        foreach (var due in dues)
        //        {
        //            var membership = memberships.FirstOrDefault(m => m.MembershipId == due.MembershipId);
        //            if (membership != null)
        //            {
        //                var member = members.FirstOrDefault(m => m.MemberId == membership.MemberId);
        //                var package = packs.FirstOrDefault(p => p.PackageId == membership.PackageId);

        //                if (member != null)
        //                {
        //                    if (member.Membership == null)
        //                    {
        //                        member.Membership = new List<Domain.MembershipEntity.Membership>();
        //                    }
        //                    membership.Member = member;
        //                    membership.Package = package;
        //                    member.Membership.Add(membership);

        //                }
        //            }
        //        }

        //        return dues;
        //    }
        //}





        public async Task HandleDuePayments()
        {
            var dueMemberPackages = await _membershipRepository.GetDueMemberPackagesAsync();

            foreach (var membership in dueMemberPackages)
            {
                var duePayment = new Domain.DuePaymentEntity.DuePayment();
                decimal dueAmount = membership.CalculateDueAmount();
                DateTime dueDate = DateTime.Now;
                duePayment.AddDue(membership.MembershipId, dueDate, dueAmount);
                membership.ExtendMemberPackageEndDate();
                await _context.DuePayments.AddAsync(duePayment);
            }

            await _context.SaveChangesAsync();
        }

    }
}
