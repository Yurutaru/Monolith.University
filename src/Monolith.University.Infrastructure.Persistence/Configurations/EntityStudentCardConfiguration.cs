using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Infrastructure.Persistence.Configurations
{
    public class EntityStudentCardConfiguration : IEntityTypeConfiguration<StudentCard>
    {
        public void Configure(EntityTypeBuilder<StudentCard> builder)
        {
            builder.ToTable("TStudentCard");
            builder.HasKey(e => e.Id);

            builder.OwnsOne(u => u.StudentCardFullName, t =>
            {
                t.Property(t => t.FirstName).HasColumnName("FirstName").HasMaxLength(256);
                t.Property(t => t.LastName).HasColumnName("LastName").HasMaxLength(256);
                t.Property(t => t.MiddleName).HasColumnName("MiddleName").HasMaxLength(256);
            });
        }
    }
   
}
