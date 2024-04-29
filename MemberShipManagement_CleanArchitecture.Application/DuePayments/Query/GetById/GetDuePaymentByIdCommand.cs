

namespace MemberShipManagement_CleanArchitecture.Application.DuePayments.Query.GetById
{
    public class GetDuePaymentByIdCommand: IRequest<IEnumerable<DuePaymentDTO>>
    {
        public int MembershipId { get; set; }
    }
}
