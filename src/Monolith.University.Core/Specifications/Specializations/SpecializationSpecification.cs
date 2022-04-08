using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Specializations
{
    public class SpecializationSpecification : Specification<Specialization>
    {
        public SpecializationSpecification()
        {
            Query.Include(t => t.Faculty);
        }
    }
}
