using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.DeleteCommand
{
    public class DeleteMemberCommand : IRequest<int>
    {
        public int MemberId { get; set; }
    }
}
