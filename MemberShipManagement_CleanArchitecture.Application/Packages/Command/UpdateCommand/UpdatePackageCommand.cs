
namespace MemberShipManagement_CleanArchitecture.Application.Packages.Command.UpdateCommand
{
    public class UpdatePackageCommand : IRequest<int>
    {
        public int PackageId { get; set; }
        public string? PackageName { get; set; }
        public string? PackageType { get; set; }
        public int Duration { get; set; }
        public decimal PackagePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
