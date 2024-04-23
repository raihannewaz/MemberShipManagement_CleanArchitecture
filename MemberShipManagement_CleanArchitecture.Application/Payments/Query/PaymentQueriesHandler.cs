using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Payments.Query
{
    internal sealed class PaymentQueriesHandler : IRequestHandler<PaymentQueries, IEnumerable<Payment>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentQueriesHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> Handle(PaymentQueries request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "AllPayments":
                    var allPay = await _paymentRepository.GetAllAsync(request.AllPayments);
                    return allPay;

                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
