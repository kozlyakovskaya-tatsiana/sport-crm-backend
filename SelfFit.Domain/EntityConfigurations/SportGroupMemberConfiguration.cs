using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfFit.Domain.Entities;

namespace SelfFit.Domain.EntityConfigurations
{
    public class SportGroupMemberConfiguration : IEntityTypeConfiguration<SportGroupMember>
    {
        public void Configure(EntityTypeBuilder<SportGroupMember> builder)
        {
            builder
                .HasOne(m => m.SportGroup)
                .WithMany(g => g.Members);
        }
    }
}
