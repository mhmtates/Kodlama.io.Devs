using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Dtos
{
    public class CreatedSocialMediaAddressDto
    {
        public int Id { get; set; }

      
        public string? SocialMediaPlatform { get; set; }
        public string? Url { get; set; }


        public int UserId { get; set; }



    }
}
