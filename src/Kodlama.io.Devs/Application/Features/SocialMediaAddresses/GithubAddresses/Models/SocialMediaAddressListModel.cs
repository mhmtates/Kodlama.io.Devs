using Application.Features.SocialMediaAddresses.GithubAddresses.Dtos;
using Core.Persistence.Paging;


namespace Application.Features.SocialMediaAddresses.GithubAddresses.Models
{
    public class SocialMediaAddressListModel:BasePageableModel
    {
        public IList<SocialMediaAddressListDto> Items { get; set; }
    }
}
