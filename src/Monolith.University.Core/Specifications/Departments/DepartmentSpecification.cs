using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Departments
{
    public class DepartmentSpecification : Specification<Department>
    {
        public DepartmentSpecification()
        {
            Query.Include(t => t.Faculty);
        }
    }
}
