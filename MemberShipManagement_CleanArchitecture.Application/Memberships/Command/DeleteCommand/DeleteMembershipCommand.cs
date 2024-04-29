

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.DeleteCommand
{
    public class DeleteMembershipCommand : IRequest<int>
    {
        public int MembershipId { get; set; }
    }
}
