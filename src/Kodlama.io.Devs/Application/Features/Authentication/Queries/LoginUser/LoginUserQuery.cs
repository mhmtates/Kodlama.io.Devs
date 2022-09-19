using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Authentication.Commands.RegisterUser
{
    public class LoginUserQuery : IRequest<LoggedInUserDto>
    {
     
        public UserForLoginDto UserForLoginDto { get; set; }



        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoggedInUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginUserQueryHandler(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, AuthenticationBusinessRules authenticationBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<LoggedInUserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                await _authenticationBusinessRules.UserMustExistWhenLogIn(user);
                await _authenticationBusinessRules.UserPasswordMustBeTrueWhenLogIn(request.UserForLoginDto.Password, user);

                List<OperationClaim> operationClaims = (await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id, include: p => p.Include(a => a.OperationClaim))).Items.Select(b => b.OperationClaim).ToList();

                AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
                LoggedInUserDto loggedInUserDto = _mapper.Map<LoggedInUserDto>(accessToken);

                return loggedInUserDto;

            }
        }
    }
}


