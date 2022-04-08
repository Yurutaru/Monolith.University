using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface IDepartmentUpdater
    {
        void Update(Department domain, UpdateDepartmentRequest document);
    }
}
