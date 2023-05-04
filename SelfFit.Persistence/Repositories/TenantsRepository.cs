using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence.Repositories
{
    public class TenantsRepository : Repository<Tenant>,ITenantRepository
    {
        public TenantsRepository(SelfFitDbContext context) : base(context)
        {
        }
    }
}
