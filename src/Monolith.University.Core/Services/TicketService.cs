using Monolith.University.Core.Contracts.Dto.Tickets;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Tickets;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> ticketRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly ITicketMapper ticketMapper;
        private readonly ITicketUpdater ticketUpdater;

        public TicketService(IRepository<Ticket> ticketRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            ITicketMapper ticketMapper,
            ITicketUpdater ticketUpdater)
        {
            this.ticketRepository = ticketRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.ticketMapper = ticketMapper;
            this.ticketUpdater = ticketUpdater;
        }

        public async Task<TicketResponse> Create(CreateTicketRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            var ticket = ticketMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await ticketRepository.Add(ticket);
                await transaction.CommitAsync();
            }

            var result = ticketMapper.Map(ticket);

            return result;
        }

        public async Task Delete(long ticketId)
        {
            if (ticketId < 0)
                throw new ArgumentOutOfRangeException(nameof(ticketId));

            var entity = await ticketRepository.GetById(ticketId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await ticketRepository.Delete(entity);
        }

        public async Task<TicketResponse> Get(long ticketId)
        {
            if (ticketId < 0)
                throw new ArgumentOutOfRangeException(nameof(ticketId));

            var ticket = await ticketRepository.GetById(ticketId);
            if (ticket == null)
                throw new ResourceNotFoundException(nameof(ticket));

            var result = ticketMapper.Map(ticket);

            return result;
        }

        public async Task<IEnumerable<TicketResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new TicketSpecification();

            var tickets = await ticketRepository.List(specification, skip, take);

            var result = ticketMapper.MapCollection(tickets);
            return result;
        }

        public async Task Update(long ticketId, UpdateTicketRequest request)
        {
            if (ticketId != request.Id)
            {
                throw new ValidationException("teacher identifier in request and in route is not identical");
            }

            var entity = await ticketRepository.GetById(ticketId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            ticketUpdater.Update(entity, request);

            await ticketRepository.Update(entity);
        }
    }
}
