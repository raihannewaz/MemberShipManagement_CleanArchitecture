

namespace MemberShipManagement_CleanArchitecture.Application.Members.Command.DeleteCommand
{
    public class DeleteMemberCommand : IRequest<int>
    {
        public int MemberId { get; set; }
    }
}
