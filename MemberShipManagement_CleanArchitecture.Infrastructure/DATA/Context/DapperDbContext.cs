

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context
{
    public class DapperDbContext: IDapperDbContext
    {
        private readonly IConfiguration _config;
        private readonly string? _dbConString;

        public DapperDbContext( IConfiguration configuration)
        {
            _config = configuration;
            _dbConString = _config.GetConnectionString("DbCon");
        }

        public IDbConnection CreateConnection()=> new SqlConnection( _dbConString );
    }
}
