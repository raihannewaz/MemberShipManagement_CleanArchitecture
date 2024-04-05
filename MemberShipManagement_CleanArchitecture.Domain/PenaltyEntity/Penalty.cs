using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PenaltyEntity
{
    public class Penalty
    {
        public int PenaltyId { get; set; }
        public int MembershipId { get; set; }
        public Membership? Membership { get; set; }

        public decimal PenaltyAmount { get; set; }
        public DateTime PenaltyDate { get; set; }
        public int MissingInstallment {  get; set; }
        public bool Status { get; set; }
    }
}
