using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Infrastructure.Persistence.Configurations
{
    public class EntityTeacherCardConfiguration : IEntityTypeConfiguration<TeacherCard>
    {
        public void Configure(EntityTypeBuilder<TeacherCard> builder)
        {
            builder.ToTable("TTeacherCard");
            builder.HasKey(e => e.Id);

            builder.OwnsOne(u => u.TeacherCardFullName, t =>
            {
                t.Property(t => t.FirstName).HasColumnName("FirstName").HasMaxLength(256);
                t.Property(t => t.LastName).HasColumnName("LastName").HasMaxLength(256);
                t.Property(t => t.MiddleName).HasColumnName("MiddleName").HasMaxLength(256);
            });
        }
    }
}
