using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence.Repositories
{
    public class SportGroupRepository : Repository<SportGroup>, ISportGroupRepository
    {
        public SportGroupRepository(SelfFitDbContext context) : base(context)
        {
        }
    }
}
