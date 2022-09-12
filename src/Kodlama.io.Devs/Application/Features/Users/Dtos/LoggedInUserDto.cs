﻿using Core.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class LoggedInUserDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
