using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Persistence.EntityTypeConfigurations
{
    internal class EntityGroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("TGroup");
            builder.HasKey(e => e.Id).HasName("TGroupId");
            builder.Property(x=>x.Name).HasMaxLength(256);

            // group-has-many-students
            builder
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
