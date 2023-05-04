using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfFit.Domain.Entities;

namespace SelfFit.Domain.EntityConfigurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<SportActivity>
    {
        public void Configure(EntityTypeBuilder<SportActivity> builder)
        {
            builder
                .HasMany(a => a.SportGroups)
                .WithOne(g => g.SportActivity)
                .OnDelete(DeleteBehavior.SetNull);
            builder
                .HasMany(a => a.SportPlaygrounds)
                .WithMany(p => p.SportActivities);
        }
    }
}
