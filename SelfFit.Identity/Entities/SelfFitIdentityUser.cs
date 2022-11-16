using System;
using Microsoft.AspNetCore.Identity;

namespace SelfFit.Identity.Entities
{
    public class SelfFitIdentityUser: IdentityUser<Guid>
    {
        public string RefreshToken { get; set; }
        public DateTimeOffset RefreshTokenExpirationDateTime { get; set; }
    }
}
