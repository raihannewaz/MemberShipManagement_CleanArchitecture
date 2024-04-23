using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Packages.Query
{
    public class PackageQueries : IRequest<IEnumerable<Package>>
    {
        public int PackageId;

        public string? Query;

        public string AllPacks = "Select * from Packages";

    }
}
