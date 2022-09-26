using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommand : IRequest<UpdatedSocialMediaAddressDto>
    {
        public UpdatedSocialMediaAddressDto UpdatedGithubAddress { get; set; }

        public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateGithubAddressCommand, UpdatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public UpdateGithubAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;

            }

            public async Task<UpdatedSocialMediaAddressDto> Handle(UpdateGithubAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress updatedGithubAddress = await _socialMediaAddressRepository.UpdateAsync(mappedSocialMediaAddress);
                UpdatedSocialMediaAddressDto updatedGithubAddressDto = _mapper.Map<UpdatedSocialMediaAddressDto>(updatedGithubAddress);
                return updatedGithubAddressDto;


            }
        }
    }
}

