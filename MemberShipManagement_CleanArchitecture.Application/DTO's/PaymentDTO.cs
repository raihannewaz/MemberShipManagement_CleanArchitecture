using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DTO_s
{
    public class PaymentDTO
    {
        public int PaymentId { get;  set; }

        public int MembershipId { get; set; }

        public DateTime PaymentDate { get; set; }

        public int AdvanceInstallMent { get; set; }

        public decimal PaidAmmount { get; set; }
    }
}
