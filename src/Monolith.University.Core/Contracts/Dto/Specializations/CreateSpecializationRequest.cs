namespace Monolith.University.Core.Contracts.Dto.Specializations
{
    public class CreateSpecializationRequest
    {
        public string? Name { get; set; }
        public decimal Duration { get; set; }

        public long FacultyId { get; set; }
    }
}
