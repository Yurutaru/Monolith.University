using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface IGroupMapper : 
        IMapper<CreateGroupRequest, Group>,
        IMapper<Group, GroupResponse>
    {
    }
}
