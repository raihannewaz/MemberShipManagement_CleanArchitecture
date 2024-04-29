
using MemberShipManagement_CleanArchitecture.Domain.Packages;

namespace MemberShipManagement_CleanArchitecture.Domain.Members
{
    public class Membership
    {
        public int MembershipId { get; private set; }

        public int MemberId { get; private set; }

        private Member? Member { get; set; }

        public int PackageId { get; private set; }

        public Package Package { get; private set; }

        private DateTime StartDate { get; set; }
        public DateTime EndDate { get; private set; }

        private int Quantity { get; set; }

        private int TotalInstallment { get; set; }

        private decimal InstallmentAmount { get; set; }



        private Membership() { }


        private Membership(int packid, int quanity)
        {

            PackageId = packid;
            Quantity = quanity;

        }

        private Membership(int memberId, int pakcageId, int quanity)
        {
            MemberId = memberId;
            PackageId = pakcageId;
            Quantity= quanity;
        }




        public void AssignPackage(Package package)
        {
            InstallmentAmount = package.PackageAmountToAssign(Quantity);
            TotalInstallment = package.PackageInstallmentToAssign(Quantity);
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(Convert.ToDouble(package.GetDuration()));
        }



        public static Membership CreateMembership(int packid, int quanity)
        {
            if (packid <= 0)
            {
                throw new Exception($"InCorrect PckageId: {packid}");
            }

            if (quanity <= 0)
            {
                throw new Exception($"InCorrect Quantity: {quanity}");
            }

            return new Membership(packid, quanity);
        }

        public static Membership CreateMembershipAfter(int memberId, int packid, int quanity)
        {
            if (memberId <= 0)
            {
                throw new Exception($"InCorrect MemberId: {memberId}");
            }
            if (packid <= 0)
            {
                throw new Exception($"InCorrect PckageId: {packid}");
            }

            if (quanity <= 0)
            {
                throw new Exception($"InCorrect Quantity: {quanity}");
            }

            return new Membership(memberId,packid, quanity);
        }



        public void UpdateMembership(int memberid, int packid, int quanity)
        {
            if (memberid! <= 0)
            {
                MemberId = memberid;
            }
            if (packid! <= 0)
            {
                PackageId = packid;
            }
            if (quanity! <= 0)
            {
                Quantity = quanity;
            }
        }



        public decimal GetInstallmentAmmount()
        {
            return InstallmentAmount;
        }

        public int GetTotalInstallment()
        {
            return TotalInstallment;
        }



        public decimal CalculateDueAmount()
        {

            decimal dueAmount = 0;

            if (Package.GetPackageType() == "Daily" || Package.GetPackageType() == "Monthly")
            {
                dueAmount = InstallmentAmount * 0.05m;
            }

            return dueAmount;
        }

        public void ExtendMemberPackageEndDate()
        {
            var package = Package;
            if (package.PackageType == "Daily")
            {
                EndDate.AddDays(1);
            }
            else if (package.PackageType == "Monthly")
            {
                EndDate.AddMonths(1);
            }
        }



        public void InstallmentMinus(decimal amount, int advInstallment)
        {
            int installmentMinus = 0;

            if (amount == InstallmentAmount)
            {
                installmentMinus = TotalInstallment - 1;
            }

            else if (advInstallment >= 2)
            {
                installmentMinus = (TotalInstallment - 1) - advInstallment;
            }
            else
            {
                throw new Exception($"Wrong Amount! Your Installment Amount Is: {InstallmentAmount}");
            }

            TotalInstallment = installmentMinus;
        }
    }


}
