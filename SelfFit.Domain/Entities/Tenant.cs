using System;
using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public virtual Contract Contract { get; set; }
        public Guid? ContractId { get; set; }
        public virtual List<SportGroup> SportGroups { get; set; }
    }
}
