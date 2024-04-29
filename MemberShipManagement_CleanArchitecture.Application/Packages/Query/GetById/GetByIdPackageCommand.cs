

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Query.GetById
{
    public class GetByIdPackageCommand : IRequest<IEnumerable<PackageDTO>>
    {
        public int PackageId { get; set; }
    }
}
