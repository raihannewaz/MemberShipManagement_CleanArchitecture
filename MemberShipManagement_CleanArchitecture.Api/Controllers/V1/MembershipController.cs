﻿using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Memberships.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Memberships.Command.DeleteCommand;
using MemberShipManagement_CleanArchitecture.Application.Memberships.Query;
using MemberShipManagement_CleanArchitecture.Application.Memberships.Query.GetAll;
using Microsoft.AspNetCore.Mvc;


namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly ISender _sender;

        public MembershipController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMembershipCommand createMembership)
        {
            var data = await _sender.Send(createMembership);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sender.Send(new DeleteMembershipCommand { MembershipId = id });
            return Ok("Deleted!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMembershipsCommand();
            var data = await _sender.Send(query);

            return Ok(data);
        }
    }
}
