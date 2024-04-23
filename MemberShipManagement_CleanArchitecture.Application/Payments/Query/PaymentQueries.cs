using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Payments.Query
{
    public class PaymentQueries : IRequest<IEnumerable<Payment>>
    {
        public string? Query;

        public string AllPayments = "Select * from Payments";
    }
}
