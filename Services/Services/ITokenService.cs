﻿using Infra.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}
