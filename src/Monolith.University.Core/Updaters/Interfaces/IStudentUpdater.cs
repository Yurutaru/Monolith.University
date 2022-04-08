using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface IStudentUpdater
    {
        void Update(Student domain, UpdateStudentRequest document);
    }
}
