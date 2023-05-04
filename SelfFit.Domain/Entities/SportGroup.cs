using System;
using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class SportGroup : BaseEntity
    {
        public string Name { get; set; }

        public virtual SportActivity SportActivity { get; set; }
        public Guid? SportActivityId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public Guid? TenantId { get; set; }
        public virtual List<SportGroupMember> Members { get; set; }
    }
}