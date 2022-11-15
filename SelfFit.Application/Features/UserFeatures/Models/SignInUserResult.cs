using System;
using System.Collections.Generic;

namespace SelfFit.Application.Features.UserFeatures.Models
{
    public class SignInUserResult
    {
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
