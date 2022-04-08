using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface IFacultyUpdater
    {
        void Update(Faculty domain, UpdateFacultyRequest document);
    }
}
