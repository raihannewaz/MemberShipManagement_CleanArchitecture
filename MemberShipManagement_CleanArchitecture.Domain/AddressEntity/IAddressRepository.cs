using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.AddressEntity
{
    public interface IAddressRepository
    {
        Task<Address> CreateAync(Address a);
        Task UpdateAsync(Address a);
        Task<Address> GetByMemberIdAndType(int memberId, string addressType);
        Task SaveChangeAsync();
    }
}
