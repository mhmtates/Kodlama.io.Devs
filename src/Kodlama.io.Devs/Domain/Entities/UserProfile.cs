using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class UserProfile : User
    { 
       
        
        public string FullName { get; set; }
        public string? ProfilePicture { get; set; }

        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string? Bio { get; set; }
        public string Location { get; set; }
        public string? CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string? WebSiteUrl { get; set; }
        public string FullAddress { get; set; }

       

      
        public DateTime BirthDate { get; set; }
       
        public virtual ICollection<SocialMediaAddress> SocialMediaAddresses { get; set; }
       
        public UserProfile()
        {
           
        }

        public UserProfile(int id, string fullName, string? profilepicture, string? bio, string? companyName, string emailAddress, string phoneNumber, string? webSiteUrl, int userId, string location, string fullAddress, DateTime birthdate, string title)
        {
            Id = id;
            FullName = fullName;
            ProfilePicture = profilepicture;
            Bio = bio;
            CompanyName = companyName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            WebSiteUrl = webSiteUrl;
            Location = location;
            FullAddress = fullAddress;
            BirthDate = birthdate;
            Title = title;
        }



    }
}
