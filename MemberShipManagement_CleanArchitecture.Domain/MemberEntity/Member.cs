using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MemberShipManagement_CleanArchitecture.Domain.MemberEntity
{
    public class Member
    {
        public int MemberId { get; private set; }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNo { get; private set; }
        public DateTime? DOB { get; private set; }

        public string? ProfileImageUrl { get; private set; }
        public DateTime AccountCreateDate { get; set; }
        public bool? IsActive { get; set; }

        public List<Document>? Document { get; set; }
        public List<Address>? Address { get; set; }
        public List<Membership>? Membership { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }


        private Member()
        {

        }



        private Member(string fName, string lName, string email, string phone, DateTime dob, IFormFile file)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            PhoneNo = phone;
            DOB = dob;
            ImageFile = file;
        }




        public static Member CreateMember(string fName, string lName, string email, string phone, DateTime dob, IFormFile file)
        {
            return new Member(fName, lName, email, phone, dob, file);
        }



        public void UpdateMember(string fName, string lName, string email, string phone, DateTime dob, IFormFile file, bool isactive)
        {
            if (fName != null)
            {
                FirstName = fName;
            }

            if (lName != null)
            {
                LastName = lName;
            }
            if (email != null)
            {
                Email = email;
            }
            if (phone != null)
            {
                PhoneNo = phone;
            }
            if (dob != DateTime.MinValue)
            {
                DOB = dob;
            }

            if (file != null)
            {
                ImageFile = file;
            }
            if (isactive != false || isactive != true)
            {
                IsActive = isactive;
            }
        }


        public void PhotoUrl(string url)
        {
            ProfileImageUrl = url;
        }

       
    }
}
