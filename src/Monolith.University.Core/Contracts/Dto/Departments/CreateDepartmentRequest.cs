namespace Monolith.University.Core.Contracts.Dto.Departments
{
    public class CreateDepartmentRequest
    {
        public string? Name { get; set; }

        public long FacultyId { get; set; }
    }
}
