using Application.Features.UserProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand:IRequest<UpdatedUserProfileDto>
    {

        public UpdatedUserProfileDto UpdatedUserProfile { get; set; }

        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile updatedUserProfile = await _userProfileRepository.UpdateAsync(mappedUserProfile);
                UpdatedUserProfileDto updatedUserProfileDto = _mapper.Map<UpdatedUserProfileDto>(updatedUserProfile);
                return updatedUserProfileDto;
            }
        }
    }
}
