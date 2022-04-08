using Monolith.University.Core.Contracts.Records;

namespace Monolith.University.Core.Contracts.Dto.People
{
    public class PersonResponse
    {
        public long Id { get; set; }
        public string? Discriminator { get; set; }

        public FullNameRecord? PersonFullName { get; set; }

        public string? Bio { get; set; }
        public DateTimeOffset? DateOfBirthday { get; set; }

        public string? UserId { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
