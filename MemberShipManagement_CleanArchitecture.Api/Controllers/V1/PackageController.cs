using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Packages.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Packages.Command.DeleteCommand;
using MemberShipManagement_CleanArchitecture.Application.Packages.Command.UpdateCommand;
using MemberShipManagement_CleanArchitecture.Application.Packages.Query;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManagement_CleanArchitecture.Api.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly ISender _sender;

        public PackageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new PackageQueries()
            {
                Query = "AllPacks"
            };
            var data = await _sender.Send(query);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePackageCommand createPackage)
        {
            var data = await _sender.Send(createPackage);

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePackageCommand updatePackage)
        {
            if (id != updatePackage.PackageId)
            {
                return BadRequest();
            }
            var data = await _sender.Send(updatePackage);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sender.Send(new DeletePackageCommand() { PackageId = id });
            return Ok("Deleted");
        }
    }
}
