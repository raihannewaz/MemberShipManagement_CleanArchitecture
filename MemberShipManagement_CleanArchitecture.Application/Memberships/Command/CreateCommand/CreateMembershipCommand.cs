using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.CreateCommand
{
    public class CreateMembershipCommand : IRequest<Membership>
    {
        public int MemberId { get; set; }

        public int PackageId { get; set; }

        public int Quantity { get; set; }

    }
}
