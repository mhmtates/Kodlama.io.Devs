using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class SocialMediaAddress : Entity
    {

        public string? SocialMediaPlatform { get; set; }
        public string? Url { get; set; }
        public int UserProfileId { get; set; }
       public virtual UserProfile UserProfile { get; set; }

     

       
        public SocialMediaAddress()
        {

        }

        public SocialMediaAddress(int id,string? socialMediaPlatform, string? url, int userProfileId) : this()
        {
            Id = id;
            SocialMediaPlatform = socialMediaPlatform;
            Url = url;
            UserProfileId = userProfileId;
           
        }

    }
}
