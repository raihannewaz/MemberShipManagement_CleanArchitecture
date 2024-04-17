﻿using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AddressCQRS.Command.UpdateCommand
{
    public class UpdateAddressCommand: IRequest<int>
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