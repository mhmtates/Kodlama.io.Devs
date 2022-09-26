using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.SocialMediaAddresses.GithubAddresses.Commands.DeleteGithubAddress
{
    public class DeleteGitHubAddressCommand : IRequest<DeletedSocialMediaAddressDto>
    {

        public int Id { get; set; }
        public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGitHubAddressCommand, DeletedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public DeleteGithubAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;

            }

            public async Task<DeletedSocialMediaAddressDto> Handle(DeleteGitHubAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress deletedGithubAddress = await _socialMediaAddressRepository.AddAsync(mappedSocialMediaAddress);
                DeletedSocialMediaAddressDto deletedGithubAddressDto = _mapper.Map<DeletedSocialMediaAddressDto>(deletedGithubAddress);
                return deletedGithubAddressDto;


            }
        }
    }
}


