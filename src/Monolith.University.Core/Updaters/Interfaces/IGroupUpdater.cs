using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface IGroupUpdater
    {
        void Update(Group domain, UpdateGroupRequest document);
    }
}
