using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;


namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommand :  IRequest<RegisteredUserDto>
    {

        public UserForRegisterDto UserForRegisterDto { get; set; }

        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<RegisteredUserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EMailAddressCannotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Status = true
                };


                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);

                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredUserDto registeredUserDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken
                };

                return registeredUserDto;
            }
        }
    }
}
