


namespace MemberShipManagement_CleanArchitecture.Domain.Addresses
{
    public interface IAddressRepository
    {
        Task<Address> CreateAync(Address a);
        Task UpdateAsync(Address a);
        Task<Address> GetByMemberIdAndType(int memberId, string addressType);
        Task SaveChangeAsync();
    }
}
