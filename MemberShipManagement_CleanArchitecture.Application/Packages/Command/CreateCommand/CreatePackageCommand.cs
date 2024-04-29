

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Command.CreateCommand
{
    public class CreatePackageCommand : IRequest<Package>
    {
        public string? PackageName { get; set; }
        public string? PackageType { get; set; }
        public int Duration { get; set; }
        public decimal PackagePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
