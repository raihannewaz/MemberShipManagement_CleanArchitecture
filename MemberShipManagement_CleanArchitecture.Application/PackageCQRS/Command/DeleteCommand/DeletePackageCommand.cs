using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.PackageCQRS.Command.DeleteCommand
{
    public class DeletePackageCommand: IRequest<int>
    {
        public int PackageId { get; set; }
    }
}
