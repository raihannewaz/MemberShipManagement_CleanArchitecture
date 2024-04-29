

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Query.GetAll
{
    internal sealed class GetAllPackagesCommandHandler : IRequestHandler<GetAllPackagesCommand, IEnumerable<PackageDTO>>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetAllPackagesCommandHandler(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public async Task<IEnumerable<PackageDTO>> Handle(GetAllPackagesCommand request, CancellationToken cancellationToken)
        {
            using (var con = _dapperDbContext.CreateConnection())
            {
                string query = "Select * from Packages";
                var result = await con.QueryAsync<PackageDTO>(query);
                return result;
            }
        }
    }
}
