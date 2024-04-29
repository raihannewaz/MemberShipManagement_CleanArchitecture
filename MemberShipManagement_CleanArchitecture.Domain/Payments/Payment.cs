using MemberShipManagement_CleanArchitecture.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.Payments
{
    public class Payment
    {
        public int PaymentId { get; private set; }

        public int MembershipId { get; private set; }
      
        public DateTime PaymentDate { get; private set; }

        private int AdvanceInstallMent {  get;  set; }

        private decimal PaidAmmount {  get;  set; } 


        private Payment() { }

        private Payment (int membershipId, int adv, decimal paidAmmount)
        {
            MembershipId = membershipId;
            PaidAmmount = paidAmmount;
            AdvanceInstallMent = adv;
            PaymentDate = DateTime.Now;
        }

        public static Payment CreatePayment(int membershipId,int adv, decimal paidAmmount)
        {
            if (membershipId <=0)
            {
                throw new Exception($"Incorrect Membership Id: {membershipId}");
            }
            if (adv < 0)
            {
                throw new Exception($"Incorrect Advance Payment: {adv}");
            }

            if (paidAmmount < 0)
            {
                throw new Exception($"Incorrect Paid Ammount: {paidAmmount}");
            }

            return new Payment(membershipId, adv, paidAmmount);
        }




    }
}
