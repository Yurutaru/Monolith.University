using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class FacultyUpdater : IFacultyUpdater
    {
        public void Update(Faculty domain, UpdateFacultyRequest document)
        {
            if (domain is null)
            {
                throw new ArgumentNullException(nameof(domain));
            }

            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            domain.Name = document.Name;
        }
    }
}
