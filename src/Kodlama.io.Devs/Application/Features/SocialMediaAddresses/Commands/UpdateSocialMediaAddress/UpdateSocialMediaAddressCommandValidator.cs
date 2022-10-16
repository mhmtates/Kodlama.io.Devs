using Application.Features.SocialMediaAddresses.Dtos;
using FluentValidation;


namespace Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress
{
    public class UpdateSocialMediaAddressCommandValidator:AbstractValidator<UpdatedSocialMediaAddressDto>
    {
        public UpdateSocialMediaAddressCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}
