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

        public int MembershipId { get; private set; }
        [JsonIgnore]
        public Membership? Membership { get;  set; }

        public DateTime PaymentDate { get; private set; }

        public int AdvanceInstallMent {  get; private set; }

        public decimal PaidAmmount {  get; private set; } 


        private Payment() { }

        private Payment (int membershipId, decimal paidAmmount)
        {
            MembershipId = membershipId;
            PaidAmmount = paidAmmount;
        }

        public static Payment CreatePayment(int membershipId, decimal paidAmmount)
        {
            return new Payment(membershipId, paidAmmount);
        }

        public void AutoSetPaymentDate(DateTime date)
        {
            PaymentDate = date;
        }

        public void AutoSetAdvancePay(int advPay)
        {
            AdvanceInstallMent = advPay;
        }
    }
}
