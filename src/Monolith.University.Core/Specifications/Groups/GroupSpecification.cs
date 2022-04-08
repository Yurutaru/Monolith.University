using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Groups
{
    public class GroupSpecification : Specification<Group>
    {
        public GroupSpecification()
        {
            Query.Include(t => t.Faculty);
            Query.Include(t => t.Course);
        }
    }
}
