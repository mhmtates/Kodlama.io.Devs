﻿using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Queries.Login;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

      
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()

            };

            RegisteredUserDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {

            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        [HttpGet("Login/{id}")]
        public async Task<IActionResult> Login([FromQuery] UserForLoginDto userForLoginDto)
        {
            LoginQuery loginQuery = new()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()

            };

            LoggedInUserDto result = await Mediator.Send(loginQuery);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.AccessToken);
        }

    }
}
