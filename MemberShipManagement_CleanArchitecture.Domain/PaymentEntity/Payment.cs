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
        private Membership? Membership { get;  set; }

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
            return new Payment(membershipId, adv, paidAmmount);
        }



        public int InstallmentMinus(decimal amount,int advInstallment, int totalInstallment, decimal installmentAmount)
        {
            int installmentMinus = 0;

            if (amount == installmentAmount)
            {
                installmentMinus = totalInstallment - 1;
            }

            else if (advInstallment >= 2)
            {
                installmentMinus = (totalInstallment - 1) - advInstallment;
            }
            return installmentMinus;
        }


    }
}
