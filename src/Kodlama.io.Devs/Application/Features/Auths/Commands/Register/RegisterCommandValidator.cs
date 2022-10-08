using Core.Security.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator:AbstractValidator<UserForRegisterDto>
    {

        public RegisterCommandValidator()
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
