using MediatR;
using MemberShipManagement_CleanArchitecture.Application.AppUsers.Command.LoginCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ISender _sender;

        public AppUserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login/")]
        public async Task<IActionResult> Login(AppUserLoginCommand appUserLogin)
        {
            var data = await _sender.Send(appUserLogin);
            return Ok(data);
        }
    }
}
