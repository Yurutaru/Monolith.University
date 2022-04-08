using Monolith.University.Core.Contracts.Records;

namespace Monolith.University.Core.Contracts.Dto.People
{
    public abstract class CreatePersonRequest
    {
        public FullNameRecord? PersonFullName { get; set; }
        public DateTimeOffset? DateOfBirthday { get; set; }

        public string? Bio { get; set; }
        public string? UserId { get; set; }
    }
}
