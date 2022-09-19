using Application.Features.SocialMediaAccounts.GithubAccount.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.GithubAccounts.Queries.GetByIdGithubAccount
{
    public class GetByIdGithubAccountQuery : IRequest<GithubAccountGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubAccountQueryHandler : IRequestHandler<GetByIdGithubAccountQuery, GithubAccountGetByIdDto>
        {
            private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
            private readonly IMapper _mapper;
            
            public GetByIdGithubAccountQueryHandler(ISocialMediaAccountRepository socialMediaAccountRepository, IMapper mapper)
            {
                _socialMediaAccountRepository = socialMediaAccountRepository;
                _mapper = mapper;
                
            }

            public async Task<GithubAccountGetByIdDto> Handle(GetByIdGithubAccountQuery request, CancellationToken cancellationToken)
            {
                SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(b => b.Id == request.Id);
                GithubAccountGetByIdDto GithubAccountGetByIdDto = _mapper.Map<GithubAccountGetByIdDto>(socialMediaAccount);
                return GithubAccountGetByIdDto;
            }
        }
    }
}

