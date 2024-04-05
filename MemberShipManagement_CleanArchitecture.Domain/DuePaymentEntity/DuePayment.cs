using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity
{
    public class DuePayment
    {
        public int DuePaymentId { get; set; }
        public int MembershipId { get; set; }
        public Membership? Membership{ get; set; }
        public DateTime DueDate { get; set; }
        public int MissedInstallment {  get; set; }
        public decimal Amount { get; set; }
    }
}
