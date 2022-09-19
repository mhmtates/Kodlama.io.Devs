using Application.Features.UserProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Technologies.Queries.GetListUserProfile
{
    public class GetByIdUserProfileQuery : IRequest<UserProfileGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, UserProfileGetByIdDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetByIdUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileGetByIdDto> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                UserProfile? userProfile = await _userProfileRepository.GetAsync(b => b.Id == request.Id);
                UserProfileGetByIdDto userProfileGetByIdDto = _mapper.Map<UserProfileGetByIdDto>(userProfile);
                return userProfileGetByIdDto;
            }

        }
    }



}
