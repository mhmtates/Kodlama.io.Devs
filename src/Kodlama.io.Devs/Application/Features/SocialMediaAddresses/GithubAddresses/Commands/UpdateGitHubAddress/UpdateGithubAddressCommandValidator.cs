using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommandValidator:AbstractValidator<UpdatedSocialMediaAddressDto>
    {
        public UpdateGithubAddressCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}
