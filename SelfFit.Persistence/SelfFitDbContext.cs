using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Domain.Entities;
using SelfFit.Domain.EntityConfigurations;
using SelfFit.Identity.Entities;

namespace SelfFit.Persistence
{
    public class SelfFitDbContext : IdentityDbContext<User, Role, Guid>
    {
        public SelfFitDbContext(DbContextOptions<SelfFitDbContext> options) : base(options)
        { }
        public DbSet<SportGroupMember> SportGroupMembers { get; set; }
        public DbSet<SportActivity> Activities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<SportGroup> SportGroups { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<SportGroupMember> Members { get; set; }
        
        public Task MigrateAsync()
        {
            return Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ActivityConfiguration());
            builder.ApplyConfiguration(new SportGroupConfiguration());
            builder.ApplyConfiguration(new SportGroupMemberConfiguration());
            builder.ApplyConfiguration(new TenantConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            
            base.OnModelCreating(builder);
        }
    }
}
