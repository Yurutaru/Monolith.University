using Monolith.University.Core.Contracts.Dto.Tickets;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponse> Create(CreateTicketRequest request);
        Task Update(long ticketId, UpdateTicketRequest request);
        Task<TicketResponse> Get(long ticketId);
        Task<IEnumerable<TicketResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long ticketId);
    }
}
