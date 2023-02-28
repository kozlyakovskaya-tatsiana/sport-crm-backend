using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence.Repositories
{
    public class SportActivityRepository : Repository<SportActivity>, ISportActivityRepository
    {
        public SportActivityRepository(SelfFitDbContext context) : base(context)
        {
        }
    }
}
