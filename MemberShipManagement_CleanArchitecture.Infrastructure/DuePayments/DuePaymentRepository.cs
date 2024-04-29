

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DuePayments
{
    internal class DuePaymentRepository : IDuePaymentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemberRepository _memberRepository;


        public DuePaymentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;

        }

        public async Task DeleteAsync(DuePayment duePayment)
        {
             _context.DuePayments.Remove(duePayment);
        }

        public async Task<DuePayment> GetById(int a)
        {
            return await _context.DuePayments.FirstOrDefaultAsync(d => d.MembershipId == a);
        }

       


        public async Task HandleDuePayments()
        {
            var dueMemberPackages = await _memberRepository.GetDueMemberPackagesAsync();

            foreach (var membership in dueMemberPackages)
            {
                var duePayment = new DuePayment();
                decimal dueAmount = membership.CalculateDueAmount();
                DateTime dueDate = DateTime.Now;
                duePayment.AddDue(membership.MembershipId, dueDate, dueAmount);
                //membership.ExtendMemberPackageEndDate();
                await _context.DuePayments.AddAsync(duePayment);
            }

            await _context.SaveChangesAsync();
        }

    }
}
