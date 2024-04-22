using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DuePaymentCQRS.Query
{
    internal sealed class DuePaymentQueriesHandler : IRequestHandler<DuePaymentQueries, IEnumerable<DuePayment>>
    {
        private readonly IDuePaymentRepository _duePaymentRepository;

        public DuePaymentQueriesHandler(IDuePaymentRepository duePaymentRepository)
        {
            _duePaymentRepository = duePaymentRepository;
        }

        public async Task<IEnumerable<DuePayment>> Handle(DuePaymentQueries request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "getMemberDues":
                    var data = request.getMemberDues(request.MembershipId);
                    var member = await _duePaymentRepository.GetDuesById(data);



                    return member;

                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
