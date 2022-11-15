namespace SelfFit.Application.Settings
{
    public class PasswordSettings
    {
        public int RequiredMinLength { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireDigit { get; set; }
    }
}
