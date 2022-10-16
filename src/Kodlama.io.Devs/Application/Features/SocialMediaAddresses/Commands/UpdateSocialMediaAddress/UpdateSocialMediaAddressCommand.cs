using Application.Features.SocialMediaAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress
{
    public class UpdateSocialMediaAddressCommand : IRequest<UpdatedSocialMediaAddressDto>
    {
        public UpdatedSocialMediaAddressDto UpdatedGithubAddress { get; set; }

        public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateSocialMediaAddressCommand, UpdatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public UpdateGithubAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;

            }

            public async Task<UpdatedSocialMediaAddressDto> Handle(UpdateSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress updatedGithubAddress = await _socialMediaAddressRepository.UpdateAsync(mappedSocialMediaAddress);
                UpdatedSocialMediaAddressDto updatedGithubAddressDto = _mapper.Map<UpdatedSocialMediaAddressDto>(updatedGithubAddress);
                return updatedGithubAddressDto;


            }
        }
    }
}

