using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Queries.Login
{
    public class LoginQuery : IRequest<LoggedInUserDto>
    {
     
        public UserForLoginDto UserForLoginDto { get; set; }

        public string IpAddress { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoggedInUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;

            public LoginQueryHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<LoggedInUserDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                User? existingUser = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                await _authBusinessRules.UserMustExistWhenLogIn(existingUser);
                await _authBusinessRules.UserPasswordMustBeTrueWhenLogIn(request.UserForLoginDto.Password, existingUser);

               AccessToken createdAccessToken = await _authService.CreateAccessToken(existingUser);
               RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(existingUser, request.IpAddress);
               RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoggedInUserDto loggedInUserDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };

                return loggedInUserDto;
            }
        }
    }
}


