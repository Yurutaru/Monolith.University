using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class CourseMapper : ICourseMapper
    {
        private readonly IFacultyMapper facultyMapper;

        public CourseMapper(IFacultyMapper facultyMapper)
        {
            this.facultyMapper = facultyMapper;
        }

        public Course Map(CreateCourseRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Course()
            {
                Name = source.Name,
                FacultyId = source.FacultyId
            };

            return result;
        }

        public CourseResponse Map(Course source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new CourseResponse()
            {
                Id = source.Id,
                Name = source.Name,
                Faculty = facultyMapper.Map(source.Faculty ?? new Faculty())
            };

            return result;
        }

    }
}
