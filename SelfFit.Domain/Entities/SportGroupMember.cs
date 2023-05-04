using System;

namespace SelfFit.Domain.Entities
{
    public class SportGroupMember : BaseEntity
    {
        public string Name { get; set; }
        public string MobilePhoneNumber { get; set; }

        public virtual SportGroup SportGroup { get; set; }
        public Guid? SportGroupId { get; set; }
    }
}
