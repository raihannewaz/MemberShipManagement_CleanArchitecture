using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.DuePayments.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    //[Authorize]
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class DuePaymentController : ControllerBase
    {

        private readonly ISender _sender;

        public DuePaymentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDues(int id)
        {
            var query = new DuePaymentQueries()
            {
                Query = "getMemberDues",
                MembershipId = id
            };

            var data = await _sender.Send(query);

            return Ok(data);
        }
    }
}
