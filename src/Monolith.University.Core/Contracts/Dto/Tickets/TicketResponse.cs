using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Core.Contracts.Dto.Teachers;

namespace Monolith.University.Core.Contracts.Dto.Tickets
{
    public class TicketResponse
    {
        public long Id { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? TicketStatus { get; set; }

        /// <summary>
        /// Attachements
        /// </summary>

        public StudentResponse? Student { get; set; }
        public TeacherResponse? Teacher { get; set; }
    }
}
