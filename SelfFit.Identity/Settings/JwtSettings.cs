namespace SelfFit.Identity.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double TokenLifeTimeInMinutes { get; set; }
        public double RefreshTokenLifeTimeInMinutes { get; set; }
    }
}