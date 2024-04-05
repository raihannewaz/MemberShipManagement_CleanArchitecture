using FluentValidation;
using MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.CreateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Validation
{
    public sealed class CreateMemberCommandValidation : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidation()
        {
            RuleFor(m => m.FirstName)
            .NotEmpty().WithMessage("First Name is Required")
            .MaximumLength(50).WithMessage("Max Character 50");

            RuleFor(m => m.LastName)
                .NotEmpty().WithMessage("Last Name is Required")
                .MaximumLength(50).WithMessage("Max Character 50");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Email is Required")
                .MaximumLength(100).WithMessage("Max Character 100")
                .EmailAddress().WithMessage("Invalid Email Address");

            RuleFor(m => m.DOB)
                .NotEmpty().WithMessage("Birthdate is Required!")
                .Must(BeAtLeast18YearsOld).WithMessage("Must be at least 18 years old.");

            RuleFor(m => m.PhoneNo)
           .NotEmpty().WithMessage("Phone Number is Required")
           .Must(phoneNo => BeAValidPhoneNumber(phoneNo!)).WithMessage("Invalid Phone Number");
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
