namespace Monolith.University.Core.Contracts.Dto.Courses
{
    public class UpdateCourseRequest
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public long FacultyId { get; set; }
    }
}
