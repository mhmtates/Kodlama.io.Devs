using Application.Features.UserProfiles.Dtos;
using FluentValidation;

namespace Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandValidator:AbstractValidator<CreatedUserProfileDto>
    {

        public CreateUserProfileCommandValidator()
        {
          
            RuleFor(a => a.FullName).NotEmpty();
            RuleFor(a => a.Bio).MaximumLength(1000);
            RuleFor(a => a.Location).NotEmpty();
            RuleFor(a => a.Location).MinimumLength(3);
            RuleFor(a => a.Title).NotEmpty();
            RuleFor(a => a.Title).MaximumLength(20);
            RuleFor(a => a.EmailAddress).NotEmpty();
            RuleFor(a => a.EmailAddress).EmailAddress();
            RuleFor(a => a.PhoneNumber).NotEmpty();
            RuleFor(a => a.FullAddress).MaximumLength(250);
            RuleFor(a => a.CompanyName).MaximumLength(30);
            RuleFor(a => a.WebSiteUrl).MaximumLength(40);
            
        }
    }
}
