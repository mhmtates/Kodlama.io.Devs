using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.GithubAddresses.Queries.GetByIdGithubAddress
{
    public class GetByIdGithubAddressQuery : IRequest<SocialMediaAddressGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubAddressQueryHandler : IRequestHandler<GetByIdGithubAddressQuery, SocialMediaAddressGetByIdDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            
            public GetByIdGithubAddressQueryHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                
            }

            public async Task<SocialMediaAddressGetByIdDto> Handle(GetByIdGithubAddressQuery request, CancellationToken cancellationToken)
            {
                SocialMediaAddress? SocialMediaAddress = await _socialMediaAddressRepository.GetAsync(b => b.Id == request.Id);
                SocialMediaAddressGetByIdDto GithubAddressGetByIdDto = _mapper.Map<SocialMediaAddressGetByIdDto>(SocialMediaAddress);
                return GithubAddressGetByIdDto;
            }
        }
    }
}

