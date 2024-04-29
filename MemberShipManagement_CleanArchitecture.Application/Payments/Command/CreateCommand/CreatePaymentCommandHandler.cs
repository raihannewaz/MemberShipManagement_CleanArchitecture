
namespace MemberShipManagement_CleanArchitecture.Application.Payments.Command.CreateCommand
{
    internal sealed class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IDuePaymentRepository _duePaymentRepository;
        private readonly IMemberRepository _memberRepository;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IDuePaymentRepository duePaymentRepository, IMemberRepository memberRepository)
        {
            _paymentRepository = paymentRepository;
            _duePaymentRepository = duePaymentRepository;
            _memberRepository = memberRepository;
        }

        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var data = Payment.CreatePayment(request.MembershipId, request.AdvanceInstallMent, request.PaidAmmount);

            var member = await _memberRepository.GetById(request.MemberId);

            member.UpdateMembershipInstallment(request.MembershipId, request.PaidAmmount, request.AdvanceInstallMent);

            var due = await _duePaymentRepository.GetById(request.MembershipId);

            if (due != null)
            {
                var updatedDueAmmount = due.UpdateDuePayment(request.PaidAmmount);

                if (updatedDueAmmount <= 0)
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
