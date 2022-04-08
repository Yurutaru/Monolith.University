using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface ISpecializationUpdater
    {
        void Update(Specialization domain, UpdateSpecializationRequest document);
    }
}
