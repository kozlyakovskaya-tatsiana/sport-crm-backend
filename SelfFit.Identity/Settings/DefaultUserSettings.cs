using System.Collections.Generic;

namespace SelfFit.Identity.Settings
{
    public class DefaultUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class DefaultUserSettings
    {
        public IEnumerable<DefaultUser> DefaultUsers { get; set; }
    }
}
