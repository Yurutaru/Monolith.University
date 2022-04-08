using Monolith.University.Domain.Enums;

namespace Monolith.University.Domain.Entities
{
    /// <summary>
    /// NOTE: consider to make a ticket types
    /// </summary>
    public class Ticket
    {
        public long Id { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public TicketStatus TicketStatus { get; set; }

        /// <summary>
        /// Attachements
        /// </summary>

        public Student? Student { get; set; }
        public long StudentId { get; set; }
        
        public Teacher? Teacher { get; set; }
        public long TeacherId { get; set; }
    }
}
