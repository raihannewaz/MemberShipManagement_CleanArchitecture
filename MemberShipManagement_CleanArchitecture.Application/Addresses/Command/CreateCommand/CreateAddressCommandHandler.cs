
using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;

namespace MemberShipManagement_CleanArchitecture.Application.Addresses.Command.CreateCommand
{
    internal sealed class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var data = Address.CreateAddress(request.AddressType, request.HouseNo, request.City, request.Region, request.PostOffice, request.PostalCode, request.Country, request.MemberId);
            await _addressRepository.CreateAync(data);
            await _addressRepository.SaveChangeAsync();
            return 0;
        }
    }
}
