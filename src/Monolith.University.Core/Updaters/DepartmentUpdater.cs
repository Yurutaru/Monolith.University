using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class DepartmentUpdater : IDepartmentUpdater
    {
        public void Update(Department domain, UpdateDepartmentRequest document)
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
            domain.FacultyId = document.FacultyId;
        }
    }
}
