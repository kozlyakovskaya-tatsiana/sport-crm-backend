using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Domain.Entities;
using SelfFit.Identity.Entities;

namespace SelfFit.Persistence
{
    public class SelfFitDbContextWithIdentity : IdentityDbContext<SelfFitIdentityUser, SelfFitRole, Guid>, ISelfFitDbContext
    {
        public SelfFitDbContextWithIdentity(DbContextOptions<SelfFitDbContextWithIdentity> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public Task MigrateAsync()
        {
            return Database.MigrateAsync();
        }
    }
}
