

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.DeleteCommand
{
    internal sealed class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;

        public DeleteMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<int> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var a = await _memberRepository.GetById(request.MemberId);
            
            if (a == null)
            {
                throw new ArgumentNullException($"Member with Id: {request.MemberId} Not Found");
            }

            await _memberRepository.DeleteAsync(a);
            await _memberRepository.SaveChangeAsync();
            return a.MemberId;
        }
    }
}
