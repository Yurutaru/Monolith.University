using Monolith.University.Core.Contracts.Dto.Groups;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface IGroupService
    {
        Task<GroupResponse> Create(CreateGroupRequest request);
        Task Update(long groupId, UpdateGroupRequest request);
        Task<GroupResponse> Get(long groupId);
        Task<IEnumerable<GroupResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long groupId);
    }
}
