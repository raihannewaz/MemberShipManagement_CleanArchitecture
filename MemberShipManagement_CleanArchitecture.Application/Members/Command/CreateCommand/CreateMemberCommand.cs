

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.CreateCommand
{
    public class CreateMemberCommand : IRequest<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public DateTime DOB { get; set; }

        public int PackageId { get; set; }

        public int Quantity { get; set; }
        
        
        public IFormFile? ImageFile { get; set; }


    }
}
