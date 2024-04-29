
namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.UpdateCommand
{
    public class UpdateMemberCommand : IRequest<int>
    {
        public int MemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public DateTime DOB { get; set; }

        public bool IsActive { get; set; }

        public IFormFile? ImageFile { get; set; }

    }
}
