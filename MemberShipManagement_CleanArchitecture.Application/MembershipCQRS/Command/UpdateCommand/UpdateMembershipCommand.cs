using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MembershipCQRS.Command.UpdateCommand
{
    public class UpdateMembershipCommand: IRequest<int>
    {
    }
}
