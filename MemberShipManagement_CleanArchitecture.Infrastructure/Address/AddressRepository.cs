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
        private readonly DapperDbContext _dapperDbContext;

        public AddressRepository(ApplicationDbContext dbContext, DapperDbContext dapperDb)
        {
            _context = dbContext;
            _dapperDbContext = dapperDb;
        }

        public async Task<Domain.AddressEntity.Address> CreateAync(Domain.AddressEntity.Address a)
        {
            await _context.Addresses.AddAsync(a);
            return a;
        }

        public Task DeleteAsync(Domain.AddressEntity.Address a)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.AddressEntity.Address> GetById(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.MemberId == id);
        }

        public async Task<Domain.AddressEntity.Address> GetByMemberIdAndType(int memberId, string addressType)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.MemberId == memberId && a.AddressType == addressType);
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.AddressEntity.Address a)
        {
            var addresses = await _context.Addresses.Where(a => a.MemberId == a.MemberId).ToListAsync();

            if (addresses == null || !addresses.Any())
            {
                throw new ArgumentException($"Addresses for Member with ID {a.MemberId} not found.");
            }

            switch (a.AddressType)
            {
                case nameof(Domain.AddressEntity.Address.EAddressType.Present):
                    var presentAddress = addresses.FirstOrDefault(a => a.AddressType == Domain.AddressEntity.Address.EAddressType.Present.ToString());
                    if (presentAddress != null)
                    {
                        _context.Entry(a).State = EntityState.Modified;
                    }
                    break;
                case nameof(Domain.AddressEntity.Address.EAddressType.Parmanent):
                    var permanentAddress = addresses.FirstOrDefault(a => a.AddressType == Domain.AddressEntity.Address.EAddressType.Parmanent.ToString());
                    if (permanentAddress != null)
                    {
                        _context.Entry(a).State = EntityState.Modified;
                    }
                    break;
                default:
                    throw new ArgumentException($"Invalid address type: {a.AddressType}");
            }

        }
      
    }
}
