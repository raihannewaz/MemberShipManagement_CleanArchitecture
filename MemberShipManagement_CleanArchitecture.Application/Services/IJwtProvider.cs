

namespace MemberShipManagement_CleanArchitecture.Domain.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser appUser);
    }
}
