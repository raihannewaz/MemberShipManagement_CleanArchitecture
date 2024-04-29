
namespace MemberShipManagement_CleanArchitecture.Infrastructure.Payments
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext dbContext, IDapperDbContext dapperDb)
        {
            _context = dbContext;
        }

        public async Task CreateAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }



        public async Task<Payment> GetById(int a)
        {
            return await _context.Payments.FirstOrDefaultAsync(p=>p.PaymentId==a);
        }


        public Task SaveChangeAsync()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }





    }
}
