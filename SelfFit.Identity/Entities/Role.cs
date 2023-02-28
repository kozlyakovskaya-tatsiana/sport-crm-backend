using System;
using Microsoft.AspNetCore.Identity;

namespace SelfFit.Identity.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        { }
        public Role(string roleName) : base(roleName)
        {

        }
    }
}
