using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Infrastructure.Persistence.Configurations
{
    public class EntityStudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("TStudent");

            builder.HasOne(s => s.StudentCard)
                .WithOne(sc => sc.Student)
                .HasForeignKey<StudentCard>(p => p.StudentId);

            builder.HasMany(s => s.Tickets)
                .WithOne(t => t.Student)
                .HasForeignKey(t => t.StudentId);
        }
    }
}
