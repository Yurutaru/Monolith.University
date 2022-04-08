using Monolith.University.Core.Contracts.Dto.Tickets;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface ITicketUpdater
    {
        void Update(Ticket domain, UpdateTicketRequest document);
    }
}
