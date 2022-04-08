using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Tickets
{
    public class TicketSpecification : Specification<Ticket>
    {
        public TicketSpecification()
        {
            Query.Include(t => t.Student);
            Query.Include(t => t.Teacher);
        }
    }
}
