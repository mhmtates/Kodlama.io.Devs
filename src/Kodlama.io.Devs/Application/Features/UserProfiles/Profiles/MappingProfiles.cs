using Application.Features.Technologies.Queries.GetListUserProfile;
using Application.Features.UserProfiles.Commands.CreateUserProfile;
using Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, CreatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, UpdatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, DeletedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, UserProfileGetByIdDto>().ReverseMap();
            CreateMap<UserProfile, GetByIdUserProfileQuery>().ReverseMap();
            CreateMap<IPaginate<UserProfile>, UserProfileListModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileListDto>().ReverseMap();
            CreateMap<UserProfile, GetListUserProfileQuery>().ReverseMap();
        }
    }
}
