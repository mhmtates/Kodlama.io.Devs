﻿using Application.Features.SocialMediaAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.Commands.DeleteSocialMediaAddress
{
    public class DeleteSocialMediaAddressCommand : IRequest<DeletedSocialMediaAddressDto>
    {

        public int Id { get; set; }
        public class DeleteSocialMediaAddressCommandHandler : IRequestHandler<DeleteSocialMediaAddressCommand, DeletedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public DeleteSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;

            }

            public async Task<DeletedSocialMediaAddressDto> Handle(DeleteSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress deletedSocialMediaAddress = await _socialMediaAddressRepository.AddAsync(mappedSocialMediaAddress);
                DeletedSocialMediaAddressDto deletedSocialMediaAddressDto = _mapper.Map<DeletedSocialMediaAddressDto>(deletedSocialMediaAddress);
                return deletedSocialMediaAddressDto;


            }
        }
    }
}


