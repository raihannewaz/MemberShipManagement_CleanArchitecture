using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
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
        public int MembershipId { get; set; }
        private Membership? Membership { get; set; }
        private DateTime DueDate { get; set; }
        private decimal Amount { get; set; }




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


        public decimal UpdateDuePayment(DuePayment duePayment, decimal amount)
        {
            return duePayment.Amount - amount;
        }
    }
}
