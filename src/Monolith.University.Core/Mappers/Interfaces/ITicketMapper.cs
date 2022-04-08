using Monolith.University.Core.Contracts.Dto.Tickets;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface ITicketMapper :
        IMapper<CreateTicketRequest, Ticket>,
        IMapper<Ticket, TicketResponse>
    {
    }
}
