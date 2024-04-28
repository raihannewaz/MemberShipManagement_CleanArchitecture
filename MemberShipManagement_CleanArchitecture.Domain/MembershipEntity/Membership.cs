using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.MembershipEntity
{
    public class Membership
    {
        public int MembershipId { get; private set; }

        public int MemberId { get; private set; }
       
        private Member? Member { get;   set; }

        public int PackageId { get; private set; }

        public Package Package { get; private set; }

        private DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  private set; }

        private int Quantity { get;  set; }

        private int TotalInstallment { get;  set; }

        private decimal InstallmentAmount { get;  set; }

        private List<Payment> Payment { get;  set; }



        private Membership() { }


        private Membership(int memberid, int packid, int quanity)
        {
            MemberId = memberid;
            PackageId = packid;
            Quantity = quanity;
          
        }




        public void AssignPackage(Package package)
        {
            InstallmentAmount = package.PackageAmountToAssign(Quantity);
            TotalInstallment = package.PackageInstallmentToAssign(Quantity);
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(Convert.ToDouble(package.GetDuration()));
        }



        public static Membership CreateMembership(int memberid, int packid, int quanity)
        {

            if (memberid <=0)
            {
                throw new Exception($"InCorrect MemberId: {memberid}");
            }

            if (packid <=0)
            {
                throw new Exception($"InCorrect PckageId: {packid}");
            }

            if (quanity <=0)
            {
                throw new Exception($"InCorrect Quantity: {quanity}");
            }

            return new Membership(memberid, packid, quanity);
        }



        public void UpdateMembership(int memberid, int packid, int quanity)
        {
            if (memberid !<= 0)
            {
                MemberId = memberid;
            }
            if (packid !<= 0)
            {
                PackageId =packid;
            }
            if (quanity !<= 0)
            {
                Quantity = quanity;
            }
        }

        public void InstallmentCalculateWithPayment(int a)
        {
            TotalInstallment = a;
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
    }


}
