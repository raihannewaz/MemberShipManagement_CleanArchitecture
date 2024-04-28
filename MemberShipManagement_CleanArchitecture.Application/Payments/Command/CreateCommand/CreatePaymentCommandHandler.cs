using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Payments.Command.CreateCommand
{
    internal sealed class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IDuePaymentRepository _duePaymentRepository ;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository,IMembershipRepository membershipRepository, IDuePaymentRepository duePaymentRepository)
        {
            _paymentRepository = paymentRepository;
            _membershipRepository = membershipRepository;
            _duePaymentRepository = duePaymentRepository;
        }

        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var data = Payment.CreatePayment(request.MembershipId, request.AdvanceInstallMent, request.PaidAmmount);
            var membership =  await _membershipRepository.GetById(request.MembershipId);
            var installment = membership.GetInstallmentAmmount();
            var totalInstallmet = membership.GetTotalInstallment();
            var InstallmentMinus = data.InstallmentMinus(request.PaidAmmount, request.AdvanceInstallMent, totalInstallmet, installment);
            membership.InstallmentCalculateWithPayment(InstallmentMinus);
            var due = await _duePaymentRepository.GetById(request.MembershipId);
            
            if (due != null)
            {
                var updatedDueAmmount = due.UpdateDuePayment(due, request.PaidAmmount);

                if (updatedDueAmmount <=0)
                {
                    await _duePaymentRepository.DeleteAsync(due);
                }
                else
                {
                    due.UpdateDue(updatedDueAmmount);
                }

            }

            await _paymentRepository.CreateAsync(data);
            await _paymentRepository.SaveChangeAsync();
            return request.MembershipId;
        }
    }
}
