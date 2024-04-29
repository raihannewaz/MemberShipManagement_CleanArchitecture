
using MemberShipManagement_CleanArchitecture.Domain.Packages;


namespace MemberShipManagement_CleanArchitecture.Domain.Members
{
    public class MembershipData
    {
        public Package Package { get; set; }
        public int Quantity { get; set; }
        public int MemberId { get; set; }

        public MembershipData(Package package, int quantity)
        {
            Package = package;
            Quantity = quantity;
        }

        public MembershipData(int memberId, Package package, int quantity)
        {
            MemberId = memberId;
            Package = package;
            Quantity = quantity;
        }
    }
}
