using Dapper;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using MemberShipManagement_CleanArchitecture.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Payments.Query.GetAll
{
    internal sealed class GetAllPaymentsCommandHandler : IRequestHandler<GetAllPaymentsCommand, IEnumerable<PaymentDTO>>
    {
        private readonly IDapperDbContext _dbContext;

        public GetAllPaymentsCommandHandler(IDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PaymentDTO>> Handle(GetAllPaymentsCommand request, CancellationToken cancellationToken)
        {

            using (var con = _dbContext.CreateConnection())
            {
                string query = "Select * from Payments";

                var result = await con.QueryAsync<PaymentDTO>(query);

                return result.ToList();
            }
        }
    }
}
