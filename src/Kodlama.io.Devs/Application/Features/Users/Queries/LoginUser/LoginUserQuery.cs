using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;


namespace Application.Features.Users.Commands.RegisterUser
{
    public class LoginUserQuery : IRequest<LoggedInUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? AuthenticatorCode { get; set; }



        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoggedInUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly ITokenHelper _tokenHelper;


            public LoginUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;

            }

            public async Task<LoggedInUserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.Email);

                _userBusinessRules.UserShouldExistWhenLogIn(user);
                _userBusinessRules.UserPasswordShouldBeTrueWhenLogIn(request.Password,request.PasswordHash,request.PasswordSalt);

                IList<OperationClaim> operationClaims = _userRepository.GetClaims(user);

                AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);

                LoggedInUserDto loggedInUserDto = _mapper.Map<LoggedInUserDto>(accessToken);
                return loggedInUserDto;
                
            }
        }
    }
}


