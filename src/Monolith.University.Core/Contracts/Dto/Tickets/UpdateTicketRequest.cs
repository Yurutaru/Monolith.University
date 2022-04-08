namespace Monolith.University.Core.Contracts.Dto.Tickets
{
    public class UpdateTicketRequest
    {
        public long Id { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? TicketStatus { get; set; }

        /// <summary>
        /// Attachements
        /// </summary>

        public long StudentId { get; set; }
        public long TeacherId { get; set; }
    }
}
