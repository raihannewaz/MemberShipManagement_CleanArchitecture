using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;


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

        private string FirstName { get;  set; }
        private string LastName { get;  set; }
        private string Email { get;  set; }
        private string PhoneNo { get;  set; }
        private DateTime DOB { get;  set; }

        private string ProfileImageUrl { get;  set; }
        private DateTime AccountCreateDate { get; set; }
        private bool IsActive { get; set; }

        private List<Document>? Document { get; set; }
        private List<Address>? Address { get; set; }
        private List<Membership>? Membership { get; set; }



        private Member()
        {

        }

      

        private Member(string fName, string lName, string email, string phone, DateTime dob)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            PhoneNo = phone;
            DOB = dob;
            AccountCreateDate = DateTime.Now;
            IsActive = true;
        }




        public static Member CreateMember(string fName, string lName, string email, string phone, DateTime dob)
        {
            return new Member(fName, lName, email, phone, dob);
        }



        public void UpdateMember(string fName, string lName, string email, string phone, DateTime dob, bool isactive)
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

            if (isactive != false || isactive != true)
            {
                IsActive = isactive;
            }
        }


        public void  PhotoUrl(string url)
        {
            ProfileImageUrl = url;
        }

        public string GetProfileImageUrl()
        {
            return ProfileImageUrl;
        }
        
    }
}
