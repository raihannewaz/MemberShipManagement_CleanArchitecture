using FluentValidation;
using MemberShipManagement_CleanArchitecture.Application.AddressCQRS.Command.CreateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.AddressCQRS.Validation
{
    public sealed class CreateAddressCommandValidation: AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidation()
        {
            RuleFor(a=>a.AddressType).NotEmpty().WithMessage("Required");

            RuleFor(a=>a.HouseNo).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 100");


            RuleFor(a=>a.City).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a=>a.Region).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a=>a.PostOffice).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a=>a.PostalCode).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a=>a.Country).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 20");
        }
    }
}
