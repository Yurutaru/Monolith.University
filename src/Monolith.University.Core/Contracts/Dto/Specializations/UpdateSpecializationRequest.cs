namespace Monolith.University.Core.Contracts.Dto.Specializations
{
    public class UpdateSpecializationRequest
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Duration { get; set; }

        public long FacultyId { get; set; }
    }
}
