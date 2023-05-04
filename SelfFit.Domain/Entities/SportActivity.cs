using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class SportActivity : BaseEntity
    {
        public string Name { get; set; }
        public decimal CostPerHourInByn { get; set; }

        public virtual List<SportPlayground> SportPlaygrounds { get; set; }
        public virtual List<SportGroup> SportGroups { get; set; }
    }
}
