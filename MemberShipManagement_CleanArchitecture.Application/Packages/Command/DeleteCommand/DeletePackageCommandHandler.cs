﻿

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Command.DeleteCommand
{
    internal sealed class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommand, int>
    {
        private readonly IPackageRepository _packageRepository;

        public DeletePackageCommandHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<int> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
        {
            var pack = await _packageRepository.GetById(request.PackageId);

            await _packageRepository.DeleteAsync(pack);
            await _packageRepository.SaveChangeAsync();
            return request.PackageId;
        }
    }
}
