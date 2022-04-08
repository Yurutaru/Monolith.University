namespace Monolith.University.Core.Contracts.Dto.Courses
{
    public class CreateCourseRequest
    {
        public string? Name { get; set; }
        public long FacultyId { get; set; }
    }
}
