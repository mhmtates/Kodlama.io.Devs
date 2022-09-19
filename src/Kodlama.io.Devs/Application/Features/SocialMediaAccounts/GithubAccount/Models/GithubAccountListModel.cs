using Application.Features.SocialMediaAccounts.GithubAccount.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAccounts.GithubAccount.Models
{
    public class GithubAccountListModel:BasePageableModel
    {
        public IList<GithubAccountListDto> Items { get; set; }
    }
}
