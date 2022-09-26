using Application.Features.SocialMediaAddresses.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.SocialMediaAddresses.GithubAddresses.Commands.DeleteGithubAddress;
using Application.Features.SocialMediaAddresses.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Application.Features.SocialMediaAddresses.GithubAddresses.Models;
using Application.Features.SocialMediaAddresses.GithubAddresses.Queries.GetByIdGithubAddress;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.SocialMediaAddresses.GithubAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMediaAddress, CreatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, CreateGitHubAddressCommand>().ReverseMap();
            CreateMap<SocialMediaAddress, UpdatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, UpdateGithubAddressCommand>().ReverseMap();
            CreateMap<SocialMediaAddress, DeletedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, DeleteGitHubAddressCommand>().ReverseMap();
            CreateMap<SocialMediaAddress, SocialMediaAddressGetByIdDto>().ReverseMap();
            CreateMap<SocialMediaAddress, GetByIdGithubAddressQuery>().ReverseMap();
            CreateMap<SocialMediaAddress, SocialMediaAddressListDto>().ReverseMap();
            CreateMap<IPaginate<SocialMediaAddress>, SocialMediaAddressListModel>().ReverseMap();
            CreateMap<SocialMediaAddress, GetListGitHubAddressQuery>().ReverseMap();

        }
    }
}
