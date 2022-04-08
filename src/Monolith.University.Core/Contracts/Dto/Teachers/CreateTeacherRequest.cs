using Monolith.University.Core.Contracts.Dto.People;

namespace Monolith.University.Core.Contracts.Dto.Teachers
{
    public class CreateTeacherRequest : CreatePersonRequest
    {
        public int FacultyId { get; set; }

        public int DepartmentId { get; set; }

        public DateTimeOffset? StartDate { get; set; }
    }
}
