using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.CreateCommand
{
    internal sealed class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, int>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IPackageRepository _packageRepository;

        public CreateMembershipCommandHandler(IMembershipRepository membershipRepository, IPackageRepository packageRepository)
        {
            _membershipRepository = membershipRepository;
            _packageRepository = packageRepository;
        }

        public async Task<int> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {
            
            var pack = await _packageRepository.GetById(request.PackageId);
            var amount = pack.PackageAmountToAssign(request.Quantity);
            var installment = pack.PackageInstallmentToAssign(request.Quantity);
            var duration = pack.GetDuration();
            var data = Membership.CreateMembership(request.MemberId, request.PackageId, request.Quantity, duration, installment, amount);
            await _membershipRepository.CreateAsync(data);
            await _membershipRepository.SaveChangeAsync();

            return request.MemberId;
        }
    }
}
