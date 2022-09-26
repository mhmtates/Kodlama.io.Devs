using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using FluentValidation;

namespace Application.Features.SocialMediaAddresses.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommandValidator:AbstractValidator<CreatedSocialMediaAddressDto>
    {
        public CreateGithubAddressCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}

