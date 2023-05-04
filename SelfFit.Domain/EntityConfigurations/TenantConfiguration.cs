using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfFit.Domain.Entities;

namespace SelfFit.Domain.EntityConfigurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder
                .HasOne(t => t.Contract)
                .WithOne(c => c.Tenant);
        }
    }
}
