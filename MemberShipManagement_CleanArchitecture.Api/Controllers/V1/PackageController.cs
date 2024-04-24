using Asp.Versioning;
using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Packages.Command.CreateCommand;
using MemberShipManagement_CleanArchitecture.Application.Packages.Command.DeleteCommand;
using MemberShipManagement_CleanArchitecture.Application.Packages.Command.UpdateCommand;
using MemberShipManagement_CleanArchitecture.Application.Packages.Query;
using MemberShipManagement_CleanArchitecture.Application.Packages.Query.GetAll;
using MemberShipManagement_CleanArchitecture.Application.Packages.Query.GetById;
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
            var query = new GetAllPackagesCommand();
            var data = await _sender.Send(query);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = new GetByIdPackageCommand() {PackageId = id};

            if (data == null)
            {
                throw new ArgumentNullException($"package with {id} not Found!");
            }

            var result = await _sender.Send(data);
            return Ok(result);
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
