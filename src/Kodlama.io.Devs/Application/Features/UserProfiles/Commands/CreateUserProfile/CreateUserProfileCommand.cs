using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommand:IRequest<CreatedUserProfileDto>
    {
        public CreatedUserProfileDto CreatedUserProfile { get; set; }

        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
           
            public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                
            }

            public async Task<CreatedUserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile addedUserProfile = await _userProfileRepository.AddAsync(mappedUserProfile);
                CreatedUserProfileDto createdUserProfileDto = _mapper.Map<CreatedUserProfileDto>(addedUserProfile);
                return createdUserProfileDto;


            }
        }
    }
}
