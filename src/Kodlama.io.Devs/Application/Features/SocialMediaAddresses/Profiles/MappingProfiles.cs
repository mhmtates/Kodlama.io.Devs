using Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.DeleteSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Queries.GetByIdSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.SocialMediaAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMediaAddress, CreatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, CreateSocialMediaAddressCommand>().ReverseMap();
            CreateMap<SocialMediaAddress, UpdatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, UpdateSocialMediaAddressCommand>().ReverseMap();
            CreateMap<SocialMediaAddress, DeletedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, DeleteSocialMediaAddressCommand>().ReverseMap();
            CreateMap<SocialMediaAddress, SocialMediaAddressGetByIdDto>().ReverseMap();
            CreateMap<SocialMediaAddress, GetByIdSocialMediaAddressQuery>().ReverseMap();
            CreateMap<SocialMediaAddress, SocialMediaAddressListDto>().ReverseMap();
            CreateMap<IPaginate<SocialMediaAddress>, SocialMediaAddressListModel>().ReverseMap();
            CreateMap<SocialMediaAddress, GetListSocialMediaAddressQuery>().ReverseMap();

        }
    }
}
