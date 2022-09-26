using Application.Features.Technologies.Queries.GetListUserProfile;
using Application.Features.UserProfiles.Commands.CreateUserProfile;
using Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Models;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            CreatedUserProfileDto result = await Mediator.Send(createUserProfileCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserProfileQuery getListUserProfileQuery = new() { PageRequest = pageRequest };
            UserProfileListModel result = await Mediator.Send(getListUserProfileQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserProfileQuery getByIdUserProfileQuery)
        {
            UserProfileGetByIdDto result = await Mediator.Send(getByIdUserProfileQuery);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserProfileCommand updateUserProfileCommand)
        {
            UpdatedUserProfileDto result = await Mediator.Send(updateUserProfileCommand);
            return Ok(result);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserProfileCommand deleteUserProfileCommand)
        {
            DeletedUserProfileDto result = await Mediator.Send(deleteUserProfileCommand);
            return Ok(result);
        }
    }
}

