using Application.Features.SocialMediaAddresses.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.SocialMediaAddresses.GithubAddresses.Commands.DeleteGithubAddress;
using Application.Features.SocialMediaAddresses.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Application.Features.SocialMediaAddresses.GithubAddresses.Models;
using Application.Features.SocialMediaAddresses.GithubAddresses.Queries.GetByIdGithubAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAddressesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGitHubAddressCommand createGithubAddressCommand)
        {
            CreatedSocialMediaAddressDto result = await Mediator.Send(createGithubAddressCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGitHubAddressQuery getListGithubAddressQuery = new() { PageRequest = pageRequest };
            SocialMediaAddressListModel result = await Mediator.Send(getListGithubAddressQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGithubAddressQuery getByIdGithubAddressQuery)
        {
            SocialMediaAddressGetByIdDto result = await Mediator.Send(getByIdGithubAddressQuery);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAddressCommand updateGithubAddressCommand)
        {
            UpdatedSocialMediaAddressDto result = await Mediator.Send(updateGithubAddressCommand);
            return Ok(result);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGitHubAddressCommand deleteGithubAddressCommand)
        {
            DeletedSocialMediaAddressDto result = await Mediator.Send(deleteGithubAddressCommand);
            return Ok(result);
        }
    }
}

