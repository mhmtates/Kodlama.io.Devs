using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMediaAddress : Entity
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int UserProfileId { get; set; }
        public SocialMediaAddress()
        {

        }

        public SocialMediaAddress(int id, string type, string url, int userProfileId) : this()
        {
            Id = id;
            Type = type;
            Url = url;
            UserProfileId = userProfileId;
        }

    }
}
