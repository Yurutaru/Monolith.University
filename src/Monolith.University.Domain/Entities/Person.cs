using Monolith.University.Domain.Entities.Interfaces;
using Monolith.University.Domain.Enums;
using Monolith.University.Domain.Records;

namespace Monolith.University.Domain.Entities
{
    public class Person : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public PersonDiscriminator Discriminator { get; set; }

        public FullName? PersonFullName { get; set; }

        public string? Bio { get; set; }
        public DateTimeOffset? DateOfBirthday { get; set; }

        public string? UserId { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
