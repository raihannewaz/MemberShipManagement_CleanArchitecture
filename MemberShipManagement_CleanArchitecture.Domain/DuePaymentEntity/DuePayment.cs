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
        public int DuePaymentId { get; private set; }
        public int MembershipId { get; private set; }
        public Membership? Membership{ get; set; }
        public DateTime DueDate { get; private set; }
        public decimal Amount { get; private set; }


        public void AddDue(int membershipId, DateTime dueDate, decimal amount)
        {
            MembershipId = membershipId;
            DueDate = dueDate;
            Amount = amount;
        }

        public void UpdateDue(decimal amount)
        {
            Amount = amount;
        }
    }
}
