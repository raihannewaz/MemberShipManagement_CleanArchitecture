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
        public string? PackageName { get;  set; }
        public string? PackageType { get;  set; }
        public int Duration { get;  set; }
        public decimal PackagePrice { get;  set; }
        public bool IsActive { get;  set; }
        public List<Membership>? Membership { get;  set; }

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




        public enum EPackageType
        {
            Daily,
            Monthly

        }

    }
}
