using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Doplan.Services.Registration.Helpers
{
    public static class UserClaimsHelper
    {
        public static UserClaimsModel GetUserClaims(HttpContext httpContext)
        {
            if (httpContext.User.Identity is not ClaimsIdentity identity)
                throw new Exception("User has no identity claims");

            var userClaims = identity.Claims.ToList();

            return new UserClaimsModel
            {
                Id = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
            };
        }
    }
}
