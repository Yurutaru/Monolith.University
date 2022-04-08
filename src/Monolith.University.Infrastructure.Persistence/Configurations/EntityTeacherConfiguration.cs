using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Infrastructure.Persistence.Configurations
{
    public class EntityTeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("TTeacher");
            builder.HasOne(s => s.TeacherCard)
                .WithOne(sc => sc.Teacher)
                .HasForeignKey<TeacherCard>(p => p.TeacherId);

            builder.HasMany(s => s.Tickets)
                .WithOne(t => t.Teacher)
                .HasForeignKey(t => t.TeacherId);
        }
    }
}
