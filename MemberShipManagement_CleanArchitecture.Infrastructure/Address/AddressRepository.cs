using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Address
{
    internal class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Domain.AddressEntity.Address> CreateAync(Domain.AddressEntity.Address a)
        {
            await _context.Addresses.AddAsync(a);
            return a;
        }



        public async Task<Domain.AddressEntity.Address> GetByMemberIdAndType(int memberId, string addressType)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.MemberId == memberId && a.AddressType == addressType);
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.AddressEntity.Address a)
        {
            _context.Entry(a).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
