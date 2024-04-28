using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MemberShipManagement_CleanArchitecture.Domain.AddressEntity
{
    public class Address
    {
        public int AddressId { get; private set; }
        public string AddressType { get; private set; }
        private string HouseNo { get;  set; }
        private string City { get;  set; }
        private string Region { get;  set; }
        private string PostOffice { get;  set; }
        private string PostalCode { get;  set; }
        private string Country { get;  set; }

        public int MemberId { get; private set; }
        private Member? Member { get; set; }


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
            if (string.IsNullOrEmpty(addressType))
            {
                throw new Exception($"Incorrect Addreess Type: {addressType}");
            }
            if (string.IsNullOrEmpty(houseNo))
            {
                throw new Exception($"Incorrect House No: {houseNo}");
            }
            if (string.IsNullOrEmpty(city))
            {
                throw new Exception($"Incorrect City: {city}");
            }
            if (string.IsNullOrEmpty(region))
            {
                throw new Exception($"Incorrect Region: {region}");
            }
            if (string.IsNullOrEmpty(postOffice))
            {
                throw new Exception($"Incorrect PostOffice: {postOffice}");
            }
            if (string.IsNullOrEmpty(postalCode))
            {
                throw new Exception($"Incorrect Postal Code: {postalCode}");
            }

            if (string.IsNullOrEmpty(country))
            {
                throw new Exception($"Incorrect Country Code: {country}");
            }
            if (memberId <=0)
            {
                throw new Exception($"Incorrect MemberId: {memberId}");
            }

            return new Address(addressType, houseNo, city, region, postOffice, postalCode, country, memberId);
        }

        public void UpdateAddress(string houseNo, string city, string region, string postOffice, string postalCode, string country)
        {
            
            if (houseNo != null)
            {
                HouseNo = houseNo;
            }
            if (city != null)
            {
                City = city;
            }
            if (region != null)
            {
                Region = region;
            }
            if (postOffice != null)
            {
                PostOffice = postOffice;
            }
            if (postalCode != null)
            {
                PostalCode = postalCode;
            }
            if (country != null)
            {
                Country = country;
            }
        }

        public string GetAddressType()
        {
            return AddressType;
        }


        public enum EAddressType
        {
            Present,
            Parmanent
        }
    }
}
