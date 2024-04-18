using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PackageEntity
{
    public interface IPackageRepository
    {
        Task<Package> CreateAsync(Package p);
        Task UpdateAsync(Package package);
        Task DeleteAsync(Package package);
        Task<Package> GetById(int a);
        Task<IEnumerable<Package>> GetAllAsync(string a);
        Task SaveChangeAsync();
    }
}
