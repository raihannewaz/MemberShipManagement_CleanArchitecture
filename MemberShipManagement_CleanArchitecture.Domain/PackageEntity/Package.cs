using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PackageEntity
{
    public class Package
    {
        public int PackageId { get; private set; }
        private string PackageName { get; set; }
        public string PackageType { get; private set; }
        private int Duration { get; set; }
        private decimal PackagePrice { get; set; }
        private bool IsActive { get; set; }

        private List<Membership>? Membership { get; set; }

        private Package() { }

        private Package(string name, string type, int duration, decimal price, bool status)
        {
            PackageName = name;
            PackageType = type;
            Duration = duration;
            PackagePrice = price;
            IsActive = status;
        }

        public static Package CreatePackage(string name, string type, int duration, decimal price, bool status)
        {
            return new Package(name, type, duration, price, status);
        }


        public void UpdatePackage(string name, string type, int duration, decimal price, bool status)
        {
            if (name != null)
            {
                PackageName = name;
            }
            if (type != null)
            {
                PackageType = type;
            }
            if (duration != 0)
            {
                Duration = duration;
            }
            if (price != 0 || price !<0)
            {
                PackagePrice = price;
            }
            if (status != false || status != true)
            {
                IsActive = status;
            }
        }



        public decimal PackageAmountToAssign(int qunaity)
        {
            decimal payAmount = 0;

            if (PackageType == EPackageType.Daily.ToString())
            {
                payAmount = Convert.ToDecimal(PackagePrice * qunaity);
            }
            if (PackageType == EPackageType.Monthly.ToString())
            {
                payAmount = Convert.ToDecimal(PackagePrice * qunaity);
            }

            return payAmount;
        }

        public int PackageInstallmentToAssign(int qunaity)
        {
           
            int installment = 0;

            if (PackageType == EPackageType.Daily.ToString())
            {
                installment = Duration * 1;
            }
            if (PackageType == EPackageType.Monthly.ToString())
            {
                installment = Duration / 30;
            }

            return installment;
        }


        public int GetDuration()
        {
            return Duration;
        }


        public string GetPackageType()
        {
            return PackageType;
        }


        public enum EPackageType
        {
            Daily,
            Monthly
        }

    }
}
