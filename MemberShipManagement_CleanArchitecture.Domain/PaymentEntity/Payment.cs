using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PaymentEntity
{
    public class Payment
    {
        public int PaymentId { get; private set; }

        public int MembershipId { get;  set; }
        [JsonIgnore]
        private Membership? Membership { get;  set; }

        public DateTime PaymentDate { get;  set; }

        public int AdvanceInstallMent {  get;  set; }

        public decimal PaidAmmount {  get;  set; } 


        private Payment() { }

        private Payment (int membershipId, int adv, decimal paidAmmount)
        {
            MembershipId = membershipId;
            PaidAmmount = paidAmmount;
            AdvanceInstallMent = adv;
        }

        public static Payment CreatePayment(int membershipId,int adv, decimal paidAmmount)
        {
            return new Payment(membershipId, adv, paidAmmount);
        }

        public void AutoSetPaymentDate(DateTime date)
        {
            PaymentDate = date;
        }

    }
}
