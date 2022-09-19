using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Rules
{
    public class AuthenticationBusinessRules
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;


        public AuthenticationBusinessRules(IUserProfileRepository userProfileRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _userProfileRepository = userProfileRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task UserEMailAddressCannotBeUsedTwiceWhenRegistered(string email)
        {
            IPaginate<UserProfile> result = await _userProfileRepository.GetListAsync(b => b.EmailAddress == email);
            if (result.Items.Any()) throw new BusinessException("This email address has been used.");
        }

        public async Task UserMustExistWhenLogIn(User? user)
        {
            if (user == null) throw new BusinessException("There is not such an user registered in the system.");
        }

        public async Task UserPasswordMustBeTrueWhenLogIn(string password,User user)
        {
            bool userPasswordVerified = HashingHelper.VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt);
            if (userPasswordVerified==false) throw new BusinessException("User password is not true.");
        }

    }
}
