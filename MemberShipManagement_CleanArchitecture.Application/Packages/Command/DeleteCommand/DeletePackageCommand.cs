

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Command.DeleteCommand
{
    public class DeletePackageCommand : IRequest<int>
    {
        public int PackageId { get; set; }
    }
}
