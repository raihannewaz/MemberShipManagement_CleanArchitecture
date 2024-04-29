namespace MemberShipManagement_CleanArchitecture.Domain.Packages
{
    public interface IPackageRepository
    {
        Task CreateAsync(Package p);
        Task UpdateAsync(Package package);
        Task DeleteAsync(Package package);
        Task<Package> GetById(int a);

        Task SaveChangeAsync();
    }
}
