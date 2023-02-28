using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class SportActivity : BaseEntity
    {
        public string Name { get; set; }
        public decimal CostPerHourInByn { get; set; }

        public List<Playground> SuitablePlaygrounds { get; set; }
        public List<SportGroup> SportGroups { get; set; }
    }
}
