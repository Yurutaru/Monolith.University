using Monolith.University.Core.Contracts.Dto.Tickets;
using Monolith.University.Core.Extensions;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Enums;

namespace Monolith.University.Core.Updaters
{
    public class TicketUpdater : ITicketUpdater
    {
        public void Update(Ticket domain, UpdateTicketRequest document)
        {
            if (domain is null)
            {
                throw new ArgumentNullException(nameof(domain));
            }

            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            domain.Subject = document.Subject;
            domain.Body = document.Body;
            domain.TicketStatus = document.TicketStatus.ToEnum<TicketStatus>();

            domain.StudentId = document.StudentId;
            domain.TeacherId = document.TeacherId;
        }
    }
}
