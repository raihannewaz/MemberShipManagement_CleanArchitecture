using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
        public DateTime DOB {  get; private set; }

        public string? ProfileImageUrl { get; set; }
        public DateTime AccountCreateDate { get; private set; }
        public bool IsActive { get; private set; }
        public List<Document>? Document { get; set; }
        public List<Address>? Address { get; set; }


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


        public static Member CreateMember(string fName, string lName, string email, string phone, DateTime dob,IFormFile file)
        {
            return new Member(fName, lName, email, phone, dob, file);
        }


        public static void AutoCreatableFieldsForMember()
        {
            var m = new Member();
            m.AccountCreateDate = DateTime.Now;
            m.IsActive = true;
        }


    }
}
