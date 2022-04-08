using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Contracts.Dto.Students;

namespace Monolith.University.Core.Contracts.Dto.Groups
{
    public class GroupResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public FacultyResponse? Faculty { get; set; }
        public CourseResponse? Course { get; set; }
        public ICollection<StudentResponse> Students { get; set; } = new List<StudentResponse>();
    }
}
