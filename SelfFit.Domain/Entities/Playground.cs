using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class Playground : BaseEntity
    {
        public string Name { get; set; }

        public List<SportActivity> SuitableActivities { get; set; }
        public List<SportGroup> SportGroups { get; set;  }
    }
}
