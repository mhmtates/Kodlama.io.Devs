using Core.Security.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.RegisterUser
{
    public class RegisterUserCommandValidator:AbstractValidator<UserForRegisterDto>
    {

        public RegisterUserCommandValidator()
        {
            RuleFor(a => a.Email).NotEmpty();
            RuleFor(a => a.Email).EmailAddress();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.Password).MinimumLength(8);
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
          
        }
    }
}
