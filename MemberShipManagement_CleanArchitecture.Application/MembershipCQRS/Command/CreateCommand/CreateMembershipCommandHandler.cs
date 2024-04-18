using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MembershipCQRS.Command.CreateCommand
{
    internal sealed class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, Membership>
    {
        private readonly IMembershipRepository _membershipRepository;

        public CreateMembershipCommandHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<Membership> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {
            var data = Membership.CreateMembership(request.MemberId, request.PackageId, request.Quantity);
            await _membershipRepository.CreateAsync(data);
            await _membershipRepository.SaveChangeAsync();
            return data;
        }
    }
}
