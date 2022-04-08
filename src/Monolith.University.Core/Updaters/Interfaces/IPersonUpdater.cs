using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface IPersonUpdater
    {
        void Update(Person domain, UpdatePersonRequest document);
    }
}
