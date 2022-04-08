using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Core.Contracts.Dto.Teachers;
using Monolith.University.Core.Contracts.Dto.Tickets;
using Monolith.University.Core.Extensions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Enums;

namespace Monolith.University.Core.Mappers
{
    public class TicketMapper : ITicketMapper
    {
        public Ticket Map(CreateTicketRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Ticket()
            {
                Subject = source.Subject,
                Body = source.Body,
                TicketStatus = source.TicketStatus.ToEnum<TicketStatus>(),
                StudentId = source.StudentId,
                TeacherId = source.TeacherId,
            };

            return result;
        }

        public TicketResponse Map(Ticket source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new TicketResponse()
            {
                Subject = source.Subject,
                Body = source.Body,
                TicketStatus = source.TicketStatus.ToString(),
                Student = source.Student == null ? new StudentResponse() : null,
                Teacher = source.Teacher == null ? new TeacherResponse() : null
            };

            return result;
        }
    }
}
