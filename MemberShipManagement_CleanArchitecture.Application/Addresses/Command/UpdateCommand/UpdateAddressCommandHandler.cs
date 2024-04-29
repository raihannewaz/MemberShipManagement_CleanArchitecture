
namespace MemberShipManagement_CleanArchitecture.Application.Addresses.Command.UpdateCommand
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

            member.UpdateAddress(request.HouseNo, request.City, request.Region, request.PostOffice, request.PostalCode, request.Country);

            await _addressRepository.UpdateAsync(member);

            await _addressRepository.SaveChangeAsync();
            return request.MemberId;
        }
    }
}
