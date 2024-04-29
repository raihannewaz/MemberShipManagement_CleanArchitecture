


namespace MemberShipManagement_CleanArchitecture.Application.Validation.AddressValidation
{
    public sealed class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidation()
        {
            RuleFor(a => a.AddressType).NotEmpty().WithMessage("Required");

            RuleFor(a => a.HouseNo).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 100");


            RuleFor(a => a.City).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a => a.Region).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a => a.PostOffice).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a => a.PostalCode).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 15");

            RuleFor(a => a.Country).NotEmpty().WithMessage("Required").MaximumLength(100).WithMessage("Length shoud be under 20");
        }
    }
}
