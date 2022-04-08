using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface ICourseMapper :
        IMapper<CreateCourseRequest, Course>,
        IMapper<Course, CourseResponse>
    {
    }
}
