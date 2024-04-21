using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.DeleteCommand;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.UpdateCommand;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _sender.Send(new MemberQueries() { MemberId = id });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand createMember)
        {
            var data = await _sender.Send(createMember);

            return Ok(data);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMemberCommand updateMember)
        {
            if (id != updateMember.MemberId)
            {
                return BadRequest();
            }
            var data = await _sender.Send(updateMember);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sender.Send(new DeleteMemberCommand() { MemberId = id });
            return Ok("Deleted");
        }
    }
}
