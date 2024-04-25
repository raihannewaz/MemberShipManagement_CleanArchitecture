using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DTO_s
{
    public class MembershipDTO
    {
        public int MembershipId { get;  set; }

        public int MemberId { get;  set; }

        public MemberDTO? Member { get; set; }

        public int PackageId { get;  set; }

        public PackageDTO? Package { get; set; }

        public DateTime? StartDate { get;  set; }
        public DateTime? EndDate { get;  set; }

        public int Quantity { get;  set; }

        public int TotalInstallment { get;  set; }

        public decimal InstallmentAmount { get;  set; }

        public List<PaymentDTO>? Payment { get; set; }
    }
}
