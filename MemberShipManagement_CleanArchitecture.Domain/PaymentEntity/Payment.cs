using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PaymentEntity
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string? MembershipId { get; set; }
        public Membership? Membership { get; set; }

        public DateTime PaymentDate { get; set; }

        public int? AdvanceInstallMent {  get; set; }

        public decimal PaidAmmount {  get; set; } 
    }
}
