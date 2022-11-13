using Microsoft.AspNetCore.Identity;

namespace SelfFit.Domain.Entities
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
