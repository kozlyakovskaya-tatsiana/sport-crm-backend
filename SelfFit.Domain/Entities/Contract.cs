using System;
using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class Contract : BaseEntity
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public List<SportGroup> Groups { get; set; }
        public Tenant Tenant { get; set; }
    }
}
