using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PackageEntity
{
    public class Package
    {
        public int PackageId { get; set; }
        public string? PackageName { get; set; }
        public string? PackageType { get; set; }
        public int Duration { get; set; }
        public decimal PackagePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
