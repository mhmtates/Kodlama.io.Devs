using Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.DeleteSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Models;
using Application.Features.SocialMediaAddresses.Queries.GetByIdGithubAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaAddressesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaAddressCommand createSocialMediaAddressCommand)
        {
            CreatedSocialMediaAddressDto result = await Mediator.Send(createSocialMediaAddressCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialMediaAddressQuery getListSocialMediaAddressQuery = new() { PageRequest = pageRequest };
            SocialMediaAddressListModel result = await Mediator.Send(getListSocialMediaAddressQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialMediaAddressQuery getByIdGithubAddressQuery)
        {
            SocialMediaAddressGetByIdDto result = await Mediator.Send(getByIdGithubAddressQuery);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaAddressCommand updateSocialMediaAddressCommand)
        {
            UpdatedSocialMediaAddressDto result = await Mediator.Send(updateSocialMediaAddressCommand);
            return Ok(result);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialMediaAddressCommand deleteSocialMediaAddressCommand)
        {
            DeletedSocialMediaAddressDto result = await Mediator.Send(deleteSocialMediaAddressCommand);
            return Ok(result);
        }
    }
}

