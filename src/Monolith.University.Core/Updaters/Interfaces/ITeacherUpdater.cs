using Monolith.University.Core.Contracts.Dto.Teachers;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface ITeacherUpdater
    {
        void Update(Teacher domain, UpdateTeacherRequest document);
    }
}
