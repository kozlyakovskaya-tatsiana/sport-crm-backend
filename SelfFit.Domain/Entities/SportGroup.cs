using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class SportGroup : BaseEntity
    {
        public string Name { get; set; }

        public SportActivity SportActivity { get; set; }
        public Tenant Tenant { get; set; }
        public Contract Contract { get; set; }
        public User Instructor { get; set; }
        public List<SportGroupMember> Members { get; set; }
    }
}
