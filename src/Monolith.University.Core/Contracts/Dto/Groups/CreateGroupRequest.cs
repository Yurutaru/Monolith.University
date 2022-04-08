namespace Monolith.University.Core.Contracts.Dto.Groups
{
    public class CreateGroupRequest
    {
        public string? Name { get; set; }

        public long FacultyId { get; set; }
        public long CourseId { get; set; }
    }
}
