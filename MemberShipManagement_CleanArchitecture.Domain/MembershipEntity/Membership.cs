using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.MembershipEntity
{
    public class Membership
    {
        public string? MembershipId { get; set; }

        public string? MemberId {  get; set; }
        public Member? Member { get; set; }

        public int PackageId {  get; set; }
        public Package? Package {  get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}

        public int Quantity { get; set; }

        public int TotalInstallment { get; set; }

        public decimal InstallmentAmount { get; set; }

    }
}
