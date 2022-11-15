using System;
using System.Collections.Generic;

namespace SelfFit.WebApi.Models.User.Responses
{
    public class SignInResultResponse
    {
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
