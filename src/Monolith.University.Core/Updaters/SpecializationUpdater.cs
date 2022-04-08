using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class SpecializationUpdater : ISpecializationUpdater
    {
        public void Update(Specialization domain, UpdateSpecializationRequest document)
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
            domain.Duration = document.Duration;
            domain.FacultyId = document.FacultyId;
        }
    }
}
