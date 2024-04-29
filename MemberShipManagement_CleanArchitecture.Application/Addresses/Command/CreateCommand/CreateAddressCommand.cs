﻿
namespace MemberShipManagement_CleanArchitecture.Application.Addresses.Command.CreateCommand
{
    public class CreateAddressCommand : IRequest<int>
    {
        public string? AddressType { get; set; }
        public string? HouseNo { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostOffice { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public int MemberId { get; set; }
    }
}
