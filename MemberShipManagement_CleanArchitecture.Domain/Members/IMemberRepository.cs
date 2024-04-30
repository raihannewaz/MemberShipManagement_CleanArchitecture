

namespace MemberShipManagement_CleanArchitecture.Domain.Members
{
    public interface IMemberRepository
    {
        Task CreateAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(Member member);
        Task<List<Membership>> GetDueMemberPackagesAsync();
        Task<Member> GetById(int a);

        void EmailAndPhoneValdator(string email, string phone);


        Task SaveChangeAsync();
    }
}
