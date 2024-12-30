using eCommerce.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email address format");


            //Password

            RuleFor(temp => temp.password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
