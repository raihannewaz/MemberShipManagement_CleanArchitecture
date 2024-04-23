using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Command.DeleteCommand
{
    public class DeleteMembershipCommand : IRequest<int>
    {
        public int MembershipId { get; set; }
    }
}
