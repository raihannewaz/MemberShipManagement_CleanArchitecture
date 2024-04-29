
namespace MemberShipManagement_CleanArchitecture.Application.Payments.Query.GetAll
{
    internal sealed class GetAllPaymentsCommandHandler : IRequestHandler<GetAllPaymentsCommand, IEnumerable<PaymentDTO>>
    {
        private readonly IDapperDbContext _dbContext;

        public GetAllPaymentsCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PaymentDTO>> Handle(GetAllPaymentsCommand request, CancellationToken cancellationToken)
        {

            using (var con = _dbContext.CreateConnection())
            {
                string query = "Select * from Payments";

                var result = await con.QueryAsync<PaymentDTO>(query);

                return result.ToList();
            }
        }
    }
}
