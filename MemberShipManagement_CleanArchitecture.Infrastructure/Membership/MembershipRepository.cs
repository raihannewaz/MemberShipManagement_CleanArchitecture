using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Membership
{
    internal class MembershipRepository : IMembershipRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DapperDbContext _dapperDbContext;

        public MembershipRepository(ApplicationDbContext dbContext, DapperDbContext dapperDb)
        {
            _context = dbContext;
            _dapperDbContext = dapperDb;
        }

        public async Task<Domain.MembershipEntity.Membership> CreateAsync(Domain.MembershipEntity.Membership p)
        {

            var package = await _context.Packages.FindAsync(p.PackageId);

            if (package == null)
            {
                throw new ArgumentNullException("Package cannot be null.");
            }

            decimal payAmount = 0;
            int installment = 0;

            if (package.PackageType == "Daily")
            {
                payAmount = Convert.ToDecimal(package.PackagePrice * p.Quantity);

                installment = package.Duration * 1;
            }
            if (package.PackageType == "Monthly")
            {
                payAmount = Convert.ToDecimal(package.PackagePrice * p.Quantity);

                installment = package.Duration / 30;
            }
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(Convert.ToDouble(package.Duration));

            p.AutoSetFileds(start, end, installment, payAmount);

            await _context.Memberships.AddAsync(p);
            return p;
        }

        public Task DeleteAsync(Domain.MembershipEntity.Membership membership)
        {
            _context.Memberships.Remove(membership);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Domain.MembershipEntity.Membership>> GetAllAsync(string a)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.MembershipEntity.Membership> GetById(int a)
        {
            return await _context.Memberships.FirstOrDefaultAsync(m => m.MembershipId == a);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.MembershipEntity.Membership membership)
        {
            throw new NotImplementedException();
        }
    }
}
