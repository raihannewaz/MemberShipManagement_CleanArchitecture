using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.PaymentCQRS.Command.CreateCommand
{
    internal sealed class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Payment>
    {
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var data = Payment.CreatePayment(request.MembershipId, request.PaidAmmount);
            await _paymentRepository.CreateAsync(data);
            await _paymentRepository.SaveChangeAsync();
            return data;
        }
    }
}
