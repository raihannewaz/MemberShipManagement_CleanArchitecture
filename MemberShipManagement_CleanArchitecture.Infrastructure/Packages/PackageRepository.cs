

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Packages
{
    internal class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task CreateAsync(Package p)
        {
            await _context.Packages.AddAsync(p);
           
        }

        public Task DeleteAsync(Package package)
        {
            _context.Packages.Remove(package);
            return Task.CompletedTask;
        }


        public async Task<Package> GetById(int a)
        {
            return await _context.Packages.FirstOrDefaultAsync(p => p.PackageId == a);
        }

        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Package package)
        {
             _context.Entry(package).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
