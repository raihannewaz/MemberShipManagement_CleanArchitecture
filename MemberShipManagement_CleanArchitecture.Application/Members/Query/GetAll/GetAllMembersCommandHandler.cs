

using MemberShipManagement_CleanArchitecture.Application.Helpers;

namespace MemberShipManagement_CleanArchitecture.Application.Members.Query.GetAll
{
    internal sealed class GetAllMembersCommandHandler : IRequestHandler<GetAllMembersCommand, Pagination<MemberDTO>>
    {
     
        private readonly IDapperDbContext _dbContext;

        public GetAllMembersCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pagination<MemberDTO>> Handle(GetAllMembersCommand request, CancellationToken cancellationToken)
        {
           
            if (request.searchTerm != null)
            {
                using (var conn = _dbContext.CreateConnection())
                {
                    string query = "SELECT* From Members Where FirstName = @name";

                    var result = await conn.QueryAsync<MemberDTO>(query, new {name = request.searchTerm});
                    var pageination = Pagination<MemberDTO>.CreatePgination(result, request.page, request.pageSize);

                    return pageination;
                }

            }

            using (var conn = _dbContext.CreateConnection())
            {
                string query = "SELECT* From Members";

                var result = await conn.QueryAsync<MemberDTO>(query);

                var pageination = Pagination<MemberDTO>.CreatePgination(result, request.page, request.pageSize);

                return pageination;
            }
        }
    }
}
