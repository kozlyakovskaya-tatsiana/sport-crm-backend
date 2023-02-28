using System.Collections.Generic;

namespace SelfFit.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
