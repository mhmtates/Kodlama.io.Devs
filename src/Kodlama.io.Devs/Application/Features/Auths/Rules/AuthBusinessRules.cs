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

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;
       


        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EMailAddressCannotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(b => b.Email == email);
            if (user!=null) throw new BusinessException("Email address already exists.");
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
