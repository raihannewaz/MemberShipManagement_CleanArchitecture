using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.AddressCQRS.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Document.Command.CreateCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ISender _sender;

        public DocumentController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateDocumentCommand createDocument)
        {
            var data = await _sender.Send(createDocument);

            return Ok(data);
        }
    }
}
