using FluentValidation;
using MemberShipManagement_CleanArchitecture.Application.Members.Command.UpdateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.MemberValidation
{
    public sealed class UpdateMemberCommandValidation : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidation()
        {
            RuleFor(m => m.FirstName)
           .MaximumLength(50).WithMessage("Max Character 50");

            RuleFor(m => m.LastName)
                .MaximumLength(50).WithMessage("Max Character 50");

            RuleFor(m => m.Email)
                .MaximumLength(100).WithMessage("Max Character 100")
                .EmailAddress().WithMessage("Invalid Email Address");

            RuleFor(m => m.DOB)
                .Must(BeAtLeast18YearsOld).WithMessage("Must be at least 18 years old.")
;

            RuleFor(m => m.PhoneNo)
                .Must(phoneNo => string.IsNullOrEmpty(phoneNo) || BeAValidPhoneNumber(phoneNo)).WithMessage("Invalid Phone Number");
        }

        private bool BeAValidPhoneNumber(string phoneNo)
        {
            string pattern = @"^(018|017|016|019|013|014|015)\d{8}$";
            return Regex.IsMatch(phoneNo, pattern);
        }

        private bool BeAtLeast18YearsOld(DateTime dob)
        {

            DateTime minDate = DateTime.Today.AddYears(-18);
            return dob <= minDate;

        }
    }
}
