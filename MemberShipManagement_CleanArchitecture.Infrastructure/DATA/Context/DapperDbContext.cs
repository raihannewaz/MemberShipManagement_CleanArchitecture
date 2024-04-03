using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context
{
    public class DapperDbContext
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
