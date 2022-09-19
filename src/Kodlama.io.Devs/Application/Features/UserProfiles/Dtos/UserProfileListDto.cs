using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Dtos
{
    public class UserProfileListDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string Title { get; set; }
        public string? Bio { get; set; }
        public string Location { get; set; }
        public string? CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? WebSiteUrl { get; set; }
        public string FullAddress { get; set; }
       public int UserId { get; set; }
       public DateTime BirthDate { get; set; }
    }
}
