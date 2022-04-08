using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Students
{
    public class StudentSpecificationGetById : Specification<Student>
    {
        public StudentSpecificationGetById(long studentId)
        {
            Query.Where(t => t.Id == studentId);
            Query.Include(t => t.Faculty);
            Query.Include(t => t.Course);
            Query.Include(t => t.Group);
            Query.Include(t => t.StudentCard);
            Query.Include(t => t.Specialization);
        }
    }
}
