using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.GithubAddresses.Dtos
{
    public class CreatedSocialMediaAddressDto
    {
        public int Id { get; set; }

        public const string Type = "Github";

        public string Url { get; set; }


        public int UserId { get; set; }



    }
}
