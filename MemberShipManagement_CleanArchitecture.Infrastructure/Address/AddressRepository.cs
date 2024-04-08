using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Domain.AddressEntity.Address> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.AddressEntity.Address a)
        {
            throw new NotImplementedException();
        }
    }
}
