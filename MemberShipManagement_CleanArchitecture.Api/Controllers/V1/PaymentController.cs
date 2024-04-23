using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Payments.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Payments.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ISender _sender;

        public PaymentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new PaymentQueries()
            {
                Query = "AllPayments"
            };
            var data = await _sender.Send(query);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentCommand createPayment)
        {
            var data = await _sender.Send(createPayment);
            return Ok(data);
        }
    }
}
