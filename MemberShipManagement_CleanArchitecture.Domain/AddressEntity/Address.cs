using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.AddressEntity
{
    public class Address
    {
        public int AddressId { get; private set; }
        public string? AddressType { get; private set; }
        public string? HouseNo { get; private set; }
        public string? City { get; private set; }
        public string? Region { get; private set; }
        public string? PostOffice { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Country { get; private set; }

        public int MemberId { get; private set; }
        public Member? Member { get; set; }


        public enum EAddressType
        {
            Present,
            Parmanent
        }

        private Address()
        {

        }

        private Address(string addressType, string houseNo, string city, string region, string postOffice, string postalCode, string country, int memberId)
        {
            AddressType = addressType;
            HouseNo = houseNo;
            City = city;
            Region = region;
            PostOffice = postOffice;
            PostalCode = postalCode;
            Country = country;
            MemberId = memberId;
        }

        public static Address CreateAddress(string addressType, string houseNo, string city, string region, string postOffice, string postalCode, string country, int memberId)
        {
            return new Address(addressType, houseNo, city, region, postOffice, postalCode, country, memberId);
        }

        
    }
}
