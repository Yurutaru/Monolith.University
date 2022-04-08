using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Persistence.EntityTypeConfigurations
{
    internal class EntityDepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("TDepartment");
            builder.HasKey(e => e.Id).HasName("TDepartmentId");
            builder.Property(x => x.Name).HasMaxLength(256);
        }
    }
}
