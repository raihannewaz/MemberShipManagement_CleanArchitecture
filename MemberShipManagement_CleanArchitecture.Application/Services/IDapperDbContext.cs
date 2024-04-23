using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Services
{
    public interface IDapperDbContext
    {
        public IDbConnection CreateConnection();
    }
}
