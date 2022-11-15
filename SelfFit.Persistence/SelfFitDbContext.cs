using Microsoft.EntityFrameworkCore;
using SelfFit.Application;

namespace SelfFit.Persistence
{
    public class SelfFitDbContext : SelfFitDbContextBase
    {
        public SelfFitDbContext(DbContextOptions<SelfFitDbContext> options) : base(options)
        {

        }
    }
}
