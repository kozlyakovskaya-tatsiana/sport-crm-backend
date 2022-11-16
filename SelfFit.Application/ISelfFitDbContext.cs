using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SelfFit.Domain.Entities;

namespace SelfFit.Application
{
    public interface ISelfFitDbContext
    {
        DbSet<Member> Members { get; set; }
        Task<int> SaveChangesAsync();
        Task MigrateAsync();
    }
}
