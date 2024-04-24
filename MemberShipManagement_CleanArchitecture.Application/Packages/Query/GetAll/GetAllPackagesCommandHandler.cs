using Dapper;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
