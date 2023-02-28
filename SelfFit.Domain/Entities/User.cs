using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SelfFit.Domain.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string RefreshToken { get; set; }
        public DateTimeOffset RefreshTokenExpirationDateTime { get; set; }

        public List<SportGroup> SportGroups { get; set; }
    }
}
