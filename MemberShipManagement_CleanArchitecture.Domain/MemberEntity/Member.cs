using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System.Text.RegularExpressions;


namespace MemberShipManagement_CleanArchitecture.Domain.MemberEntity
{
    public class Member
    {


        public int MemberId { get; private set; }

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string PhoneNo { get; set; }
        private DateTime DOB { get; set; }

        private string ProfileImageUrl { get; set; }
        private DateTime AccountCreateDate { get; set; }
        private bool IsActive { get; set; }

        private List<Document>? Document { get; set; }
        private List<Address>? Address { get; set; }
        private List<Membership> Memberships { get;  set; }



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
            if (string.IsNullOrEmpty(fName))
            {
                throw new Exception($"Incorrect First Name: {fName}");
            }

            if (string.IsNullOrEmpty(lName))
            {
                throw new Exception($"Incorrect Last Name: {lName}");
            }

            if (!BeAValidPhoneNumber(phone))
            {
                throw new Exception($"Invalid Phone Number: {phone}");
            }

            if (!BeAtLeast18YearsOld(dob))
            {
                throw new Exception($"Date of Birth indicates the person is not at least 18 years old: {dob}");
            }


            return new Member(fName, lName, email, phone, dob);
        }

        private static bool BeAValidPhoneNumber(string phoneNo)
        {
            string pattern = @"^(018|017|016|019|013|014|015)\d{8}$";
            return Regex.IsMatch(phoneNo, pattern);
        }

        private static bool BeAtLeast18YearsOld(DateTime dob)
        {
            DateTime minDate = DateTime.Today.AddYears(-18);
            return dob <= minDate;
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

        public string GetFirstName()
        {
            return FirstName;
        }
        public string GetPhone()
        {
            return PhoneNo;
        }

    }
}
