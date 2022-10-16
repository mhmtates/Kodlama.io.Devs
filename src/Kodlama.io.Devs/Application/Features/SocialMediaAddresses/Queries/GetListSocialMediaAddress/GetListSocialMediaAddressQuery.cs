using Application.Features.SocialMediaAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMediaAddresses.Queries.GetByIdGithubAddress
{
    public class GetListSocialMediaAddressQuery : IRequest<SocialMediaAddressListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListGithubAddressQueryHandler : IRequestHandler<GetListSocialMediaAddressQuery, SocialMediaAddressListModel>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListGithubAddressQueryHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaAddressListModel> Handle(GetListSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMediaAddress> SocialMediaAddresses = await _socialMediaAddressRepository.GetListAsync(include:
                                              m => m.Include(c => c.UserProfile),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
                SocialMediaAddressListModel socialMediaAddressListModel = _mapper.Map<SocialMediaAddressListModel>(SocialMediaAddresses);
                return socialMediaAddressListModel;

            }
        }

    }
}


