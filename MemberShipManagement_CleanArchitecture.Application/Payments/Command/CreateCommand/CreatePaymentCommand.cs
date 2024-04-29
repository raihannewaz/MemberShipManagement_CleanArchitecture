

namespace MemberShipManagement_CleanArchitecture.Application.Payments.Command.CreateCommand
{
    public class CreatePaymentCommand : IRequest<int>
    {

        public int MembershipId { get; set; }
        public int MemberId {  get; set; }
        public int AdvanceInstallMent { get; set; }
        public decimal PaidAmmount { get; set; }

    }
}
