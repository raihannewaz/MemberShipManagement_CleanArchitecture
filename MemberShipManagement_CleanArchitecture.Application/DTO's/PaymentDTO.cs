

namespace MemberShipManagement_CleanArchitecture.Application.DTO_s
{
    public class PaymentDTO
    {
        public int PaymentId { get;  set; }

        public int MembershipId { get; set; }

        public DateTime PaymentDate { get; set; }

        public int AdvanceInstallMent { get; set; }

        public decimal PaidAmmount { get; set; }
    }
}
