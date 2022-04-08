using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Persistence.EntityTypeConfigurations
{
    internal class EntityFacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("TFaculty");
            builder.HasKey(e => e.Id).HasName("TFacuiltyId");
            builder.Property(x => x.Name).HasMaxLength(256);

            // faculty-has-many-departments
            builder
                .HasMany(g => g.Departments)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-specializations
            builder
                .HasMany(g => g.Specializations)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-courses
            builder
                .HasMany(g => g.Courses)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-groups
            builder
                .HasMany(g => g.Groups)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-students
            builder
                .HasMany(g => g.Students)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-studentCards
            builder
                .HasMany(g => g.StudentCards)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-teacherCards
            builder
                .HasMany(g => g.Teacher)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            // faculty-has-many-teacherCards
            builder
                .HasMany(g => g.TeacherCards)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
