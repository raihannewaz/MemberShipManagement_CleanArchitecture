using FluentValidation;
using MemberShipManagement_CleanArchitecture.Application.MembershipCQRS.Command.CreateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MembershipCQRS.Validation
{
    internal sealed class CreateMembershipCommandValidation: AbstractValidator<CreateMembershipCommand>
    {
        public CreateMembershipCommandValidation()
        {
            RuleFor(m => m.MemberId).NotEmpty().WithMessage("MemberId Is Reuired");
            RuleFor(m => m.PackageId).NotEmpty().WithMessage("PackageId Is Reuired");
            RuleFor(m => m.Quantity).NotEmpty().WithMessage("Quantity Is Reuired");

        }
    }
}
