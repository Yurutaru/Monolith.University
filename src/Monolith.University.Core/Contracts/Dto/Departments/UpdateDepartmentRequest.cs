namespace Monolith.University.Core.Contracts.Dto.Departments
{
    public class UpdateDepartmentRequest
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public long FacultyId { get; set; }
    }
}
