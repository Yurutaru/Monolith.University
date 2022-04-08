using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Records;

namespace Monolith.University.Core.Updaters
{
    public abstract class PersonUpdater
    {
        public virtual void Update(Person domain, UpdatePersonRequest document)
        {
            if (domain is null)
            {
                throw new ArgumentNullException(nameof(domain));
            }

            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            domain.PersonFullName = new FullName(document.PersonFullName?.FirstName,
                document.PersonFullName?.MiddleName, document.PersonFullName?.LastName);

            domain.Bio = document.Bio;
            domain.DateOfBirthday = document.DateOfBirthday;
            //domain.UserId = document.UserId;
            domain.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
