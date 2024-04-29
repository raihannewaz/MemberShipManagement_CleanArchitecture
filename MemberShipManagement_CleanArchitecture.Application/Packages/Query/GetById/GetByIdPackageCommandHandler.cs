

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Query.GetById
{
    internal sealed class GetByIdPackageCommandHandler : IRequestHandler<GetByIdPackageCommand, IEnumerable<PackageDTO>>
    {
        private readonly IDapperDbContext _dbContext;

        public GetByIdPackageCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PackageDTO>> Handle(GetByIdPackageCommand request, CancellationToken cancellationToken)
        {
            using (var conn =  _dbContext.CreateConnection())
            {
                string query = $"select * from Packages Where PackageId = {request.PackageId}";

                var data = await conn.QueryAsync<PackageDTO>(query);

                return data;
            }
        }
    }
}
