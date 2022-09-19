using Application.Features.Technologies.Models;

using Application.Features.Technologies.Rules;
using Application.Features.UserProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListUserProfile
{
    public class GetListUserProfileQuery : IRequest<UserProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserProfileQueryHandler : IRequestHandler<GetListUserProfileQuery, UserProfileListModel>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileListModel> Handle(GetListUserProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfile> userProfiles = await _userProfileRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                UserProfileListModel mappedUserProfileListModel = _mapper.Map<UserProfileListModel>(userProfiles);
                return mappedUserProfileListModel;
            }
        }

    }
}


