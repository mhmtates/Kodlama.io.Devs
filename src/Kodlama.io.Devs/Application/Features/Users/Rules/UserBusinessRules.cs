﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEMailAddressShouldNotBeExistWhenRegistered(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.Email == email);
            if (result.Items.Any()) throw new BusinessException("User email address exists.");
        }

        public void UserShouldExistWhenLogIn(User? user)
        {
            if (user == null) throw new BusinessException("Requested user does not exist.");
        }

        public void UserPasswordShouldBeTrueWhenLogIn(string password,byte[]PasswordHash,byte[]PasswordSalt)
        {
            bool userPasswordVerified = HashingHelper.VerifyPasswordHash(password,PasswordHash,PasswordSalt);
            if (userPasswordVerified==false) throw new BusinessException("User password is not true.");
        }

    }
}