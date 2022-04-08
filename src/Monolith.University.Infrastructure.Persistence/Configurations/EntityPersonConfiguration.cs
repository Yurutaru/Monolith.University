using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Infrastructure.Persistence.Configurations
{
    internal class EntityPersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("TPerson");
            builder.HasKey(e => e.Id);

            builder.OwnsOne(u => u.PersonFullName, t =>
            {
                t.Property(t => t.FirstName).HasColumnName("FirstName").HasMaxLength(256);
                t.Property(t => t.LastName).HasColumnName("LastName").HasMaxLength(256);
                t.Property(t => t.MiddleName).HasColumnName("MiddleName").HasMaxLength(256);
            });
        }
    }
}
