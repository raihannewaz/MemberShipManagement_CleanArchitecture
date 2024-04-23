using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        public List<Document>? Document { get; set; }
        public List<Address>? Address { get; set; }
        public List<Membership>? Membership { get; set; }


        public IFormFile? ImageFile { get; set; }
    }
}
