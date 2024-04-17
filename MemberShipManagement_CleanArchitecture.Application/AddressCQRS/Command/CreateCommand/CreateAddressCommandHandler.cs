using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AddressCQRS.Command.CreateCommand
{
    internal sealed class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Address>
    {
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var data = Address.CreateAddress(request.AddressType,request.HouseNo,request.City,request.Region,request.PostOffice,request.PostalCode,request.Country,request.MemberId);
            await _addressRepository.CreateAync(data);
            await _addressRepository.SaveChangeAsync();
            return data;
        }
    }
}
