

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.CreateCommand
{
    public class CreateMembershipCommand : IRequest<int>
    {
        public int MemberId { get; set; }

        public int PackageId { get; set; }

        public int Quantity { get; set; }

    }
}
