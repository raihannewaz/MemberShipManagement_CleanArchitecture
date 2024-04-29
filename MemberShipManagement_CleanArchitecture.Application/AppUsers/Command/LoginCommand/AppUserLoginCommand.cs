
namespace MemberShipManagement_CleanArchitecture.Application.AppUsers.Command.LoginCommand
{
    public class AppUserLoginCommand : IRequest<string>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }


    }
}
