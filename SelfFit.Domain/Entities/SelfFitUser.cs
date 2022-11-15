using System;
using Microsoft.AspNetCore.Identity;

namespace SelfFit.Domain.Entities
{
    public class SelfFitUser : IdentityUser<Guid>
    {
        public int Year { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset RefreshTokenExpirationDateTime { get; set; }
    }
}
