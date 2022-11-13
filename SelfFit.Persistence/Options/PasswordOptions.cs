namespace SelfFit.Persistence.Options
{
    public class PasswordOptions
    {
        public int RequiredMinLength { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireDigit { get; set; }
    }
}
