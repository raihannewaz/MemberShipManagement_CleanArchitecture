using MemberShipManagement_CleanArchitecture.Domain.Members;

namespace MemberShipManagement_CleanArchitecture.Domain.DuePayments
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


        public decimal UpdateDuePayment(decimal amount)
        {
            return Amount - amount;
        }
    }
}
