

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Query.GetAll
{
    internal sealed class GetAllMembershipsCommandHandler : IRequestHandler<GetAllMembershipsCommand, IEnumerable<MembershipDTO>>
    {
        private readonly IDapperDbContext _dbContext;

        public GetAllMembershipsCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MembershipDTO>> Handle(GetAllMembershipsCommand request, CancellationToken cancellationToken)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                string query = "Select * from Memberships";

                var result = await conn.QueryAsync<MembershipDTO>(query);

                return result;
            }
        }
    }
}
