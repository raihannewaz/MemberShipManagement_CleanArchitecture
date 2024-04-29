

namespace MemberShipManagement_CleanArchitecture.Domain.DuePayments
{
    public interface IDuePaymentRepository
    {
        Task HandleDuePayments();

        Task<DuePayment> GetById(int a);

        Task DeleteAsync(DuePayment duePayment);
    }
}
