
namespace MemberShipManagement_CleanArchitecture.Application.DTO_s
{
    public class MemberDTO
    {
        public int MemberId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DOB { get; set; }

        public string ProfileImageUrl { get; set; }
        public DateTime AccountCreateDate { get; set; }
        public bool IsActive { get; set; }

        public List<DocumentDTO>? Document { get; set; }
        public List<AddressDTO>? Address { get; set; }
        public List<MembershipDTO>? Membership { get; set; }


        public IFormFile ImageFile { get; set; }
    }
}
