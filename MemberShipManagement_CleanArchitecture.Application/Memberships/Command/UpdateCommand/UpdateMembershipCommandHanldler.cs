using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.UpdateCommand
{
    internal sealed class UpdateMembershipCommandHanldler : IRequestHandler<UpdateMembershipCommand, int>
    {
        private readonly IMembershipRepository _membershipRepository;

        public UpdateMembershipCommandHanldler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public Task<int> Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
