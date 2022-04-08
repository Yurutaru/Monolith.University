using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Students
{
    public class StudentSpecification : Specification<Student>
    {
        public StudentSpecification()
        {
            Query.Include(t => t.Faculty);
            Query.Include(t => t.Course);
            Query.Include(t => t.Group);
            Query.Include(t => t.StudentCard);
        }
    }
}
