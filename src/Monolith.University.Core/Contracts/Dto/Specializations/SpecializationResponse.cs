using Monolith.University.Core.Contracts.Dto.Faculties;

namespace Monolith.University.Core.Contracts.Dto.Specializations
{
    public class SpecializationResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Duration { get; set; }

        public FacultyResponse? Faculty { get; set; }
    }
}
