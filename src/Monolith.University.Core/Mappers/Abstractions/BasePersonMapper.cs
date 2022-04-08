using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Records;

namespace Monolith.University.Core.Mappers.Abstractions
{
    public abstract class BasePersonMapper<TDomain,TContract>
        where TDomain : Person, new()
        where TContract : PersonResponse, new()
    {
        public virtual Person Map(CreatePersonRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var personFullName = source.PersonFullName ?? throw new ArgumentNullException(nameof(source.PersonFullName));

            var result = new TDomain() {

                Bio = source.Bio,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,
                PersonFullName = new FullName(personFullName.FirstName, personFullName.MiddleName, personFullName.LastName),
                DateOfBirthday = source.DateOfBirthday,
                UserId = source.UserId
            };

            return result;
        }

        public virtual PersonResponse Map(Person source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            var personFullName = source.PersonFullName ?? throw new ArgumentNullException(nameof(source.PersonFullName));

            var result = new TContract()
            {
                Id= source.Id, 
                Bio = source.Bio,
                CreatedAt =source.CreatedAt,
                UpdatedAt = source.UpdatedAt,
                DateOfBirthday=source.DateOfBirthday,
                Discriminator = source.Discriminator.ToString(),
                PersonFullName = new Contracts.Records.FullNameRecord(personFullName.FirstName, personFullName.MiddleName, personFullName.LastName),
                UserId = source.UserId
            };

            return result;
        }
    }
}
