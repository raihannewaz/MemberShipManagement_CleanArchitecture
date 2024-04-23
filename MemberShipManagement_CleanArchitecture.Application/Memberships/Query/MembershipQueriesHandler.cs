using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Query
{
    internal sealed class MembershipQueriesHandler : IRequestHandler<MembershipQueries, IEnumerable<Membership>>
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipQueriesHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IEnumerable<Membership>> Handle(MembershipQueries request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "allMembership":
                    var allmship = await _membershipRepository.GetAllAsync(request.allMembership);
                    return allmship;

                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
