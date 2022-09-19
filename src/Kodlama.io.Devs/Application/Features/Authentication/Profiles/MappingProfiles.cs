using Application.Features.Authentication.Commands.RegisterUser;
using Application.Features.Authentication.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;


namespace Application.Features.Authentication.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserForLoginDto>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<AccessToken, RegisteredUserDto>().ReverseMap();
            CreateMap<AccessToken, LoggedInUserDto>().ReverseMap();
        }
    }
}
