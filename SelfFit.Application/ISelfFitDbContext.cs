using Microsoft.EntityFrameworkCore;
using SelfFit.Domain.Entities;
using System.Threading.Tasks;

namespace SelfFit.Application
{
    public interface ISelfFitDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}
