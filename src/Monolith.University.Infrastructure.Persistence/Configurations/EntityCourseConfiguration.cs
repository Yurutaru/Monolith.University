using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Persistence.EntityTypeConfigurations
{
    internal class EntityCourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TCourse");
            builder.HasKey(t=>t.Id).HasName("TCourseId");
            builder.Property(x => x.Name).HasMaxLength(256);

            // course-has-many-groups
            builder
                .HasMany(g => g.Groups)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // course-has-many-students
            builder
                .HasMany(g => g.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
