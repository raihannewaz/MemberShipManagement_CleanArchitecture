

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Addresses
{
    internal class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Address> CreateAync(Address a)
        {
            await _context.Addresses.AddAsync(a);
            return a;
        }



        public async Task<Address> GetByMemberIdAndType(int memberId, string addressType)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.MemberId == memberId && a.AddressType == addressType);
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Address a)
        {
            _context.Entry(a).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
