using Ardalis.Specification;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Specifications.Courses
{
    public class CourseSpecification : Specification<Course>
    {
        public CourseSpecification()
        {
            Query.Include(t => t.Faculty);
        }
    }
}
