using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Contracts.Records;

namespace Monolith.University.Core.Contracts.Dto.TeacherCard
{
    public class TeacherCardResponse
    {
        public long Id { get; set; }

        public FullNameRecord? TeacherCardFullName { get; set; }

        public FacultyResponse? Faculty { get; set; }

        public DepartmentResponse? Department { get; set; }

        public DateTimeOffset? StartDate { get; set; }
    }
}
