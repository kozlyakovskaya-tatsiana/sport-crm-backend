using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfFit.Domain.Entities;

namespace SelfFit.Domain.EntityConfigurations
{
    public class SportGroupConfiguration : IEntityTypeConfiguration<SportGroup>
    {
        public void Configure(EntityTypeBuilder<SportGroup> builder)
        {
            builder
                .HasMany(g => g.Members)
                .WithOne(m => m.SportGroup)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(g => g.Tenant)
                .WithMany(t => t.SportGroups);

            builder
                .HasOne(g => g.SportActivity)
                .WithMany(a => a.SportGroups);
        }
    }
}
