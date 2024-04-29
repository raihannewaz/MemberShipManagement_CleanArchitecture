

//namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.DeleteCommand
//{
//    internal sealed class DeleteMembershipCommandHandler : IRequestHandler<DeleteMembershipCommand, int>
//    {

//        private readonly IMembershipRepository _membershipRepository;

//        public DeleteMembershipCommandHandler(IMembershipRepository membershipRepository)
//        {
//            _membershipRepository = membershipRepository;
//        }

//        public async Task<int> Handle(DeleteMembershipCommand request, CancellationToken cancellationToken)
//        {
//            var data = await _membershipRepository.GetById(request.MembershipId);
//            await _membershipRepository.DeleteAsync(data);
//            await _membershipRepository.SaveChangeAsync();
//            return request.MembershipId;
//        }
//    }
//}
