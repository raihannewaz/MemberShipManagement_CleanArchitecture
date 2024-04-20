using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.MembershipEntity
{
    public class Membership
    {
        public int MembershipId { get; private set; }

        public int MemberId { get; private set; }
        [JsonIgnore]
        public Member? Member { get;  set; }

        public int PackageId { get; private set; }
        [JsonIgnore]
        public Package? Package { get;  set; }

        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public int Quantity { get; private set; }

        public int TotalInstallment { get; private set; }

        public decimal InstallmentAmount { get; private set; }

        public List<Payment> Payment { get;  set; }


        private Membership() { }

        private Membership(int memberid, int packid, int quanity)
        {
            MemberId = memberid;
            PackageId = packid;
            Quantity = quanity;
        }

        public static Membership CreateMembership(int memberid, int packid, int quanity)
        {
            return new Membership(memberid, packid, quanity);
        }

        public void AutoSetFileds(DateTime start, DateTime end, int installment, decimal amount)
        {
            StartDate = start;
            EndDate = end;
            TotalInstallment = installment;
            InstallmentAmount = amount;
        }

        public void UpdateMembership(int memberid, int packid, int quanity)
        {
            if (memberid != 0)
            {
                MemberId = memberid;
            }
            if (packid != 0)
            {
                PackageId =packid;
            }
            if (quanity != 0 || quanity !<0)
            {
                Quantity = quanity;
            }
        }

        public void InstallmentCalculateWithPayment(int a)
        {
            TotalInstallment = a;
        }


        public void DueDateCalculate(DateTime end)
        {
            EndDate = end;
        }

    }


}
