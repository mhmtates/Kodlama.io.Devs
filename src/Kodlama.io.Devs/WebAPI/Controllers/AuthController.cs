using Application.Features.Authentication.Commands.RegisterUser;
using Application.Features.Authentication.Dtos;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> Login([FromQuery]LoginUserQuery loginUserQuery)
        {
            LoggedInUserDto result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand  registerUserCommand)
        {
            RegisteredUserDto result = await Mediator.Send(registerUserCommand);
            return Created("",result);
        }

    }
}
