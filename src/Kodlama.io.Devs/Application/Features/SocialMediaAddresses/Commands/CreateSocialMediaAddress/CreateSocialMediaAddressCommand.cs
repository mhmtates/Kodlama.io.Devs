using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress
{
    public class CreateSocialMediaAddressCommand : IRequest<CreatedSocialMediaAddressDto>
    {
        public string Url{ get; set; }

        public int UserProfileId { get; set; }
        public class CreateSocialMediaAddressCommandHandler : IRequestHandler<CreateSocialMediaAddressCommand, CreatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddressBusinessRules _socialMediaAddressBusinessRules;

            public CreateSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper, SocialMediaAddressBusinessRules socialMediaAddressBusinessRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddressBusinessRules = socialMediaAddressBusinessRules;
            }

            public async Task<CreatedSocialMediaAddressDto> Handle(CreateSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaAddressBusinessRules.SocialMediaAddressUrlCannotBeDuplicatedWhenInserted(request.Url);
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress addedSocialMediaAddress = await _socialMediaAddressRepository.AddAsync(mappedSocialMediaAddress);
                CreatedSocialMediaAddressDto createdSocialMediaAddressDto = _mapper.Map<CreatedSocialMediaAddressDto>(addedSocialMediaAddress);
                return createdSocialMediaAddressDto;


            }
        }
    }
}

