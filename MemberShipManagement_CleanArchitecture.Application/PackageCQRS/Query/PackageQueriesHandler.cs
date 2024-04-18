using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.PackageCQRS.Query
{
    internal sealed class PackageQueriesHandler : IRequestHandler<PackageQueries, IEnumerable<Package>>
    {
        private readonly IPackageRepository _packageRepository;

        public PackageQueriesHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<IEnumerable<Package>> Handle(PackageQueries request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "AllPacks":
                    var allPack = await _packageRepository.GetAllAsync(request.AllPacks);
                    return allPack;

                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
