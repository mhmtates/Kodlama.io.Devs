using Application.Features.SocialMediaAddresses.Dtos;
using FluentValidation;

namespace Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress
{
    public class CreateSocialMediaAddressCommandValidator:AbstractValidator<CreatedSocialMediaAddressDto>
    {
        public CreateSocialMediaAddressCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}

