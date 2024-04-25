using Dapper;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DuePayments.Query.GetById
{
    internal sealed class GetDuePaymentByIdCommandHandler : IRequestHandler<GetDuePaymentByIdCommand, IEnumerable<DuePaymentDTO>>
    {
        private readonly IDapperDbContext _dbContext;

        public GetDuePaymentByIdCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DuePaymentDTO>> Handle(GetDuePaymentByIdCommand request, CancellationToken cancellationToken)
        {
            using (var conn = _dbContext.CreateConnection())
            {

                string query = @$"SELECT DueDate, Amount FROM DuePayments WHERE MembershipId = {request.MembershipId}
                                  SELECT InstallmentAmount FROM Memberships WHERE MembershipId = {request.MembershipId}
                                  SELECT FirstName, LastName, PhoneNo, DOB FROM Members
                                  SELECT PackageName, PackageType FROM Packages";


                var result = await conn.QueryMultipleAsync(query);


                var dues = await result.ReadAsync<DuePaymentDTO>();
                var memberships = await result.ReadAsync<MembershipDTO>();
                var members = await result.ReadAsync<MemberDTO>();
                var packages = await result.ReadAsync<PackageDTO>();

                foreach (var due in dues)
                {
                    due.Membership = memberships.FirstOrDefault();
                    due.Membership.Member = members.FirstOrDefault();
                    due.Membership.Package = packages.FirstOrDefault();
                }

                return dues;
            }

        }
    }
}
