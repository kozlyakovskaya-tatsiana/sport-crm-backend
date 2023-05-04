using System;
using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class SportPlayground : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<SportActivity> SportActivities { get; set; }
        public virtual Image Image { get; set; }
        public Guid ImageId { get; set; }
    }
}
