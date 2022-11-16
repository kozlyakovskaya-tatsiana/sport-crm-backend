using System;
using Microsoft.AspNetCore.Identity;

namespace SelfFit.Identity.Entities
{
    public class SelfFitRole : IdentityRole<Guid>
    {
        public SelfFitRole()
        { }
        public SelfFitRole(string roleName) : base(roleName)
        {

        }
    }
}
