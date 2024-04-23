using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Addresses.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Addresses.Command.UpdateCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ISender _sender;

        public AddressController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand createAddress)
        {
            var data = await _sender.Send(createAddress);

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAddressCommand updateAddress)
        {
            if (id != updateAddress.MemberId)
            {
                return BadRequest();
            }
            var data = await _sender.Send(updateAddress);

            return Ok(data);
        }

    }
}
