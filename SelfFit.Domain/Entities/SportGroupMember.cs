namespace SelfFit.Domain.Entities
{
    public class SportGroupMember : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber { get; set; }

        public SportGroup SportGroup { get; set; }
    }
}
