

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetAll
{
    internal sealed class GetAllMembersCommandHandler : IRequestHandler<GetAllMembersCommand, IEnumerable<MemberDTO>>
    {
     
        private readonly IDapperDbContext _dbContext;

        public GetAllMembersCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MemberDTO>> Handle(GetAllMembersCommand request, CancellationToken cancellationToken)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                string query = "SELECT* From Members";

                var result = await conn.QueryAsync<MemberDTO>(query);

                return result.ToList();
            }
        }
    }
}
