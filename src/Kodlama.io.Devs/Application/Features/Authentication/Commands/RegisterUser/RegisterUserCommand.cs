using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;


namespace Application.Features.Authentication.Commands.RegisterUser
{
    public class RegisterUserCommand :  IRequest<RegisteredUserDto>
    {

        public UserForRegisterDto UserForRegisterDto { get; set; }
      
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;
            private readonly ITokenHelper _tokenHelper;


            public RegisterUserCommandHandler(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, AuthenticationBusinessRules authenticationBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
                _tokenHelper = tokenHelper;

            }
            public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _authenticationBusinessRules.UserEMailAddressCannotBeUsedTwiceWhenRegistered(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User? mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.Status = true;

                User createdUser = await _userRepository.AddAsync(mappedUser);

                const string ClaimName = "User";
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(a => a.Name == ClaimName);

                IList<OperationClaim> operationClaims = (await _userOperationClaimRepository.GetListAsync(a => a.UserId == createdUser.Id)).Items.Select(a => a.OperationClaim).ToList();

                AccessToken accessToken = _tokenHelper.CreateToken(createdUser, operationClaims);

                RegisteredUserDto registeredUserDto = _mapper.Map<RegisteredUserDto>(accessToken);
                return registeredUserDto;
            }
        }
    }
}
