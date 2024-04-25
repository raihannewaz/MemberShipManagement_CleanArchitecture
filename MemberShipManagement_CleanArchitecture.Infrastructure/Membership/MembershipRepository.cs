using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using static System.Net.Mime.MediaTypeNames;
using Dapper;
using MemberShipManagement_CleanArchitecture.Application.Services;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Membership
{
    internal class MembershipRepository : IMembershipRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IDapperDbContext _dapperDbContext;

        public MembershipRepository(ApplicationDbContext dbContext, IDapperDbContext dapperDb)
        {
            _context = dbContext;
            _dapperDbContext = dapperDb;
        }

        public async Task CreateAsync(Domain.MembershipEntity.Membership p)
        {
            await _context.Memberships.AddAsync(p);
        }

        public Task DeleteAsync(Domain.MembershipEntity.Membership membership)
        {
            _context.Memberships.Remove(membership);
            return Task.CompletedTask;
        }



        public async Task<Domain.MembershipEntity.Membership> GetById(int a)
        {
            return await _context.Memberships.FirstOrDefaultAsync(m => m.MembershipId == a);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }



        public async Task<List<Domain.MembershipEntity.Membership>> GetDueMemberPackagesAsync()
        {
            var currentDate = DateTime.Now;

            var dueMemberPackages = await _context.Memberships
                .Include(mp => mp.Package)
                .Where(mp => mp.EndDate < currentDate && !_context.Payments.Any(p => p.MembershipId == mp.MembershipId && p.PaymentDate.Date == currentDate.Date))
                .ToListAsync();

            return dueMemberPackages;
        }

    }
}
