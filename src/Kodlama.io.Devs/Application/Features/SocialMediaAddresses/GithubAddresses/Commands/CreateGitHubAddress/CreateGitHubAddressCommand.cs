using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGitHubAddressCommand : IRequest<CreatedSocialMediaAddressDto>
    {
        public CreatedSocialMediaAddressDto CreatedGithubAddress { get; set; }

        public class CreateGithubAddressCommandHandler : IRequestHandler<CreateGitHubAddressCommand, CreatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public CreateGithubAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;

            }

            public async Task<CreatedSocialMediaAddressDto> Handle(CreateGitHubAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress addedGithubAddress = await _socialMediaAddressRepository.AddAsync(mappedSocialMediaAddress);
                CreatedSocialMediaAddressDto createdGithubAddressDto = _mapper.Map<CreatedSocialMediaAddressDto>(addedGithubAddress);
                return createdGithubAddressDto;


            }
        }
    }
}

