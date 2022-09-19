﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAccounts.GithubAccount.Dtos
{
    public class GithubAccountGetByIdDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public int UserProfileId { get; set; }
    }
}
