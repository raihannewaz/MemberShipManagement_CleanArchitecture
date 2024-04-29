

namespace MemberShipManagement_CleanArchitecture.Application.DTO_s
{
    public class DuePaymentDTO
    {
        public int DuePaymentId { get;  set; }
        public int MembershipId { get;  set; }
        public MembershipDTO? Membership { get; set; }
        public DateTime DueDate { get;  set; }
        public decimal Amount { get;  set; }
    }
}
