using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Payments.Command.CreateCommand
{
    public class CreatePaymentCommand : IRequest<Payment>
    {

        public int MembershipId { get; set; }
        public int AdvanceInstallMent { get; set; }
        public decimal PaidAmmount { get; set; }

    }
}
