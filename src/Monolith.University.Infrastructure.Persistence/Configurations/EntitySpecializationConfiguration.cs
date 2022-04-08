using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Persistence.EntityTypeConfigurations
{
    internal class EntitySpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("TSpecialization");
            builder.HasKey(e => e.Id).HasName("TSpecializationId");
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Duration).HasPrecision(3, 2);

            // specialization-has-many-students
            builder
                .HasMany(g => g.Students)
                .WithOne(s => s.Specialization)
                .HasForeignKey(s => s.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
