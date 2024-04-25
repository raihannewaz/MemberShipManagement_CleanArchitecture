using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DuePayments.Query.GetById
{
    public class GetDuePaymentByIdCommand: IRequest<IEnumerable<DuePaymentDTO>>
    {
        public int MembershipId { get; set; }
    }
}
