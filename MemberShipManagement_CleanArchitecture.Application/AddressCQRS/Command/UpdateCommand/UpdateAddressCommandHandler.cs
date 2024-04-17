using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AddressCQRS.Command.UpdateCommand
{
    internal sealed class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, int>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public async Task<int> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var member = await _addressRepository.GetByMemberIdAndType(request.MemberId, request.AddressType);
            if (member == null)
            {
                throw new ArgumentException($"Member with ID {request.MemberId} not found.");
            }

            member.UpdateAddress(request.AddressType, request.HouseNo, request.City, request.Region, request.PostOffice, request.PostalCode, request.Country);

            await _addressRepository.UpdateAsync(member);

            await _addressRepository.SaveChangeAsync();
            return request.MemberId;
        }
    }
}
