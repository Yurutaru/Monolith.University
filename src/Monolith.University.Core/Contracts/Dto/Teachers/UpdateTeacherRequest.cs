using Monolith.University.Core.Contracts.Dto.People;

namespace Monolith.University.Core.Contracts.Dto.Teachers
{
    public class UpdateTeacherRequest : UpdatePersonRequest
    {
        public long FacultyId { get; set; }
        public long DepartmentId { get; set; }
    }
}
