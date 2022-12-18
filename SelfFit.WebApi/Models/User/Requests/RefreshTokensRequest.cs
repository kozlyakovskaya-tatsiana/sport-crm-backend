namespace SelfFit.WebApi.Models.User.Requests
{
    public class RefreshTokensRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
