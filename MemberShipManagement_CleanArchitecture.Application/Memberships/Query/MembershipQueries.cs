using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Memberships.Query
{
    public class MembershipQueries : IRequest<IEnumerable<Membership>>
    {

        public string? Query;

        public string allMembership = "SELECT * From Memberships";

    }
}
