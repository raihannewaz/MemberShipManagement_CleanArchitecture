using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.MembershipEntity
{
    public interface IMembershipRepository
    {
        Task<Membership> CreateAsync(Membership p);
        //Task UpdateAsync(Membership membership);
        Task DeleteAsync(Membership membership);
        Task<Membership> GetById(int a);
        //Task<IEnumerable<Membership>> GetAllAsync(string a);
        Task SaveChangeAsync();

        Task<List<Membership>> GetDueMemberPackagesAsync();
    }
}
