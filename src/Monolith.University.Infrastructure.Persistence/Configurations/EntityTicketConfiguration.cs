using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Infrastructure.Persistence.Configurations
{
    public class EntityTicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("TTicket");
            builder.HasKey(e => e.Id).HasName("TicketId");
            builder.Property(x => x.Subject).HasColumnName("Subject").HasMaxLength(256);
            builder.Property(x => x.Body).HasColumnName("Body").HasMaxLength(8000);
        }
    }
}
