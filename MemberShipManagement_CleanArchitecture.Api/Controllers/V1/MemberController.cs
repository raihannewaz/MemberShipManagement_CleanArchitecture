using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.CreateCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ISender _sender;

        public MemberController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand createMember)
        {
            var data = await _sender.Send(createMember);

            return Ok(data);
        }
    }
}
