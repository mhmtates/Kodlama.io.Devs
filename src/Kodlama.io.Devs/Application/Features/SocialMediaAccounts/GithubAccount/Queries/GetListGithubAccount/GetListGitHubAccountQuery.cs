using Application.Features.SocialMediaAccounts.GithubAccount.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GithubAccounts.Queries.GetByIdGithubAccount
{
    public class GetListGithubAccountQuery : IRequest<GithubAccountListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListGithubAccountQueryHandler : IRequestHandler<GetListGithubAccountQuery, GithubAccountListModel>
        {
            private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
            private readonly IMapper _mapper;

            public GetListGithubAccountQueryHandler(ISocialMediaAccountRepository socialMediaAccountRepository, IMapper mapper)
            {
                _socialMediaAccountRepository = socialMediaAccountRepository;
                _mapper = mapper;
            }

            public async Task<GithubAccountListModel> Handle(GetListGithubAccountQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMediaAccount> socialMediaAccounts = await _socialMediaAccountRepository.GetListAsync(include:
                                              m => m.Include(c => c.UserProfile),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
                GithubAccountListModel GithubAccountListModel = _mapper.Map<GithubAccountListModel>(socialMediaAccounts);
                return GithubAccountListModel;

            }
        }

    }
}


