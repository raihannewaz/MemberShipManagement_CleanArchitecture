using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AppUserCQRS.Command.CreateCommand
{
    internal sealed class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, Package>
    {
        private readonly IPackageRepository _packageRepository;

        public CreatePackageCommandHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<Package> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var data = Package.CreatePackage(request.PackageName, request.PackageType, request.Duration, request.PackagePrice, request.IsActive);

            await _packageRepository.CreateAsync(data);
            await _packageRepository.SaveChangeAsync();
            return data;
        }
    }
}
