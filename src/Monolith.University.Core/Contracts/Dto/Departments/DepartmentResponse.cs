using Monolith.University.Core.Contracts.Dto.Faculties;

namespace Monolith.University.Core.Contracts.Dto.Departments
{
    public class DepartmentResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public FacultyResponse? Faculty { get; set; }
    }
}
