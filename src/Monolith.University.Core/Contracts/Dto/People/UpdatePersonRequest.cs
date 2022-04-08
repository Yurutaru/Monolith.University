using Monolith.University.Core.Contracts.Records;

namespace Monolith.University.Core.Contracts.Dto.People
{
    public abstract class UpdatePersonRequest
    {
        public long Id { get; set; }
        public string? Bio { get; set; }
        public FullNameRecord? PersonFullName { get; set; }
        public DateTimeOffset? DateOfBirthday { get; set; }
    }
}
