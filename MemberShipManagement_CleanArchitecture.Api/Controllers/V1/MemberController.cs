using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Members.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Members.Command.DeleteCommand;
using MemberShipManagement_CleanArchitecture.Application.Members.Command.UpdateCommand;
using MemberShipManagement_CleanArchitecture.Application.Members.Query.GetAll;
using MemberShipManagement_CleanArchitecture.Application.Members.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    //[Authorize]
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

        [HttpGet("allMembers")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMembersCommand();

            var data = await _sender.Send(query);

            return Ok(data);
        }


        [HttpGet("{id}/documents/addresses/memberships")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _sender.Send(new GetMemberByIdCommand() { MemberId = id });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateMemberCommand createMember)
        {
            var data = await _sender.Send(createMember);

            return Ok(data);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateMemberCommand updateMember)
        {
            if (id != updateMember.MemberId)
            {
                return BadRequest();
            }
            var data = await _sender.Send(updateMember);

            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sender.Send(new DeleteMemberCommand() { MemberId = id });
            return Ok("Deleted");
        }
    }
}
