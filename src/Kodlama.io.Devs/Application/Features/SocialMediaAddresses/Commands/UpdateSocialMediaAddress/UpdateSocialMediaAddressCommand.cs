using Application.Features.SocialMediaAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress
{
    public class UpdateSocialMediaAddressCommand : IRequest<UpdatedSocialMediaAddressDto>
    {
        public UpdatedSocialMediaAddressDto UpdatedSocialMediaAddress { get; set; }

        public class UpdateSocialMediaAddressCommandHandler : IRequestHandler<UpdateSocialMediaAddressCommand, UpdatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;

            }

            public async Task<UpdatedSocialMediaAddressDto> Handle(UpdateSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress updatedSocialMediaAddress = await _socialMediaAddressRepository.UpdateAsync(mappedSocialMediaAddress);
                UpdatedSocialMediaAddressDto updatedSocialMediaAddressDto = _mapper.Map<UpdatedSocialMediaAddressDto>(updatedSocialMediaAddress);
                return updatedSocialMediaAddressDto;


            }
        }
    }
}

