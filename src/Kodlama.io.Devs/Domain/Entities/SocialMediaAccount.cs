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
    public class SocialMediaAccount : Entity
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int UserId { get; set; }
        public SocialMediaAccount()
        {

        }

        public SocialMediaAccount(int id, string type, string url, int userid) : this()
        {
            Id = id;
            Type = type;
            Url = url;
            UserId = userid;
        }

    }
}
