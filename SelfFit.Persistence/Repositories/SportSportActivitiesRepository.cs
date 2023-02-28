using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence.Repositories
{
    public class SportSportActivitiesRepository : Repository<SportActivity>, ISportActivitiesRepository
    {
        public SportSportActivitiesRepository(SelfFitDbContext context) : base(context)
        {
        }
    }
}
