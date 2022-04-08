using Monolith.University.Core.Contracts.Dto.Faculties;

namespace Monolith.University.Core.Contracts.Dto.Courses
{
    public class CourseResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public FacultyResponse? Faculty { get; set; }
    }
}
