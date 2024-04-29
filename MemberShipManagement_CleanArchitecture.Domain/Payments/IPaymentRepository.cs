namespace MemberShipManagement_CleanArchitecture.Domain.Payments
{
    public interface IPaymentRepository
    {
        Task CreateAsync(Payment payment);
        
        Task<Payment> GetById(int a);
        Task SaveChangeAsync();
    }
}
