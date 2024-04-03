using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberShipManagement_CleanArchitecture.Domain.MemberEntity
{
    public class Member
    {
        public string? MemberId { get; set; } 

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNo { get; set; }
        public DateOnly DOB {  get; set; }

        public string? ProfileImageUrl { get; set; }
        public DateTime AccountCreateDate { get; set; }
        public bool IsActive { get; set; }
        public List<Document>? Document { get; set; }
        public List<Address>? Addresses { get; set; }

        public IFormFile? ImageFile { get; set; }

    }
}
