using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.PackageCQRS.Command.UpdateCommand
{
    internal sealed class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommand, int>
    {
        private readonly IPackageRepository _packageRepository;

        public UpdatePackageCommandHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<int> Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
        {
            var package = await _packageRepository.GetById(request.PackageId);
            if (package == null)
            {
                throw new ArgumentException($"Package with ID {request.PackageId} not found.");
            }
            package.UpdatePackage(request.PackageName, request.PackageType, request.Duration, request.PackagePrice, request.IsActive);

            await _packageRepository.UpdateAsync(package);
            await _packageRepository.SaveChangeAsync();

            return request.PackageId;
        }
    }
}
