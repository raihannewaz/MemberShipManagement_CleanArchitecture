
using MemberShipManagement_CleanArchitecture.Domain.Addresses;
using MemberShipManagement_CleanArchitecture.Domain.Documents;
using System.Text.RegularExpressions;


namespace MemberShipManagement_CleanArchitecture.Domain.Members
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
        public List<Membership> Memberships { get; private set; }



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
            Document = new List<Document>();
            Address = new List<Address>();
            Memberships = new List<Membership>();
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

        public string GetLatName()
        {
            return LastName;
        }
        public string GetPhone()
        {
            return PhoneNo;
        }

        public void ManageMembership(MembershipData membership)
        {

            var existingMembership = Memberships.FirstOrDefault(m => m.PackageId == membership.Package.PackageId);

            if (existingMembership == null)
            {
                var newMembership = Membership.CreateMembership(membership.Package.PackageId, membership.Quantity);
                newMembership.AssignPackage(membership.Package);

                Memberships.Add(newMembership);

            }

        }

        public void ManageMembershipAfter(MembershipData membership)
        {
            var existingMembership = Memberships.FirstOrDefault(m => m.MemberId == membership.MemberId);
            if(existingMembership != null)
            {
                var newMembership = Membership.CreateMembershipAfter(membership.MemberId, membership.Package.PackageId, membership.Quantity);
                newMembership.AssignPackage(membership.Package);
                Memberships.Add(newMembership);
            }
        }

        public void UpdateMembershipInstallment(int membershipId, decimal amount, int advancePayment)
        {
            var membership = Memberships.FirstOrDefault(m => m.MembershipId == membershipId);

            if (membership != null)
            {
                membership.InstallmentMinus(amount, advancePayment);
            }
        }

    }
}
