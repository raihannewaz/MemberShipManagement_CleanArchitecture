
namespace MemberShipManagement_CleanArchitecture.Application.Services
{
    public interface IDapperDbContext
    {
        public IDbConnection CreateConnection();
    }
}
