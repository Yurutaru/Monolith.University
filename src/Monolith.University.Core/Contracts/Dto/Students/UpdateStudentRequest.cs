using Monolith.University.Core.Contracts.Dto.People;

namespace Monolith.University.Core.Contracts.Dto.Students
{
    public class UpdateStudentRequest : UpdatePersonRequest
    {
        public long FacultyId { get; set; }
        public long SpecializationId { get; set; }
        public long CourseId { get; set; }
        public long GroupId { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
