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
    public class RegisterUserCommand : IRequest<RegisteredUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,RegisteredUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly ITokenHelper _tokenHelper;
            

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
                
            }

            public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserEMailAddressShouldNotBeExistWhenRegistered(request.Email);

                HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                User? mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.Status = true;
                mappedUser.AuthenticatorType = AuthenticatorType.None;

                User registeredUser = await _userRepository.AddAsync(mappedUser);
                IList<OperationClaim> operationClaims = _userRepository.GetClaims(mappedUser);

                AccessToken accessToken = _tokenHelper.CreateToken(registeredUser, operationClaims);

                RegisteredUserDto registeredUserDto = _mapper.Map<RegisteredUserDto>(accessToken);
                return registeredUserDto;
             }
        }
    }
}
