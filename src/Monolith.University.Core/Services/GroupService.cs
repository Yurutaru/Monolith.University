using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Groups;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> groupRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly IGroupMapper groupMapper;
        private readonly IGroupUpdater groupUpdater;

        public GroupService(IRepository<Group> groupRepository,
            IUnitOfWorkFactory unitOfWorkFactory, 
            IGroupMapper groupMapper,
            IGroupUpdater groupUpdater)
        {
            this.groupRepository = groupRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.groupMapper = groupMapper;
            this.groupUpdater = groupUpdater;
        }

        public async Task<GroupResponse> Create(CreateGroupRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            var department = groupMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await groupRepository.Add(department);
                await transaction.CommitAsync();
            }

            var result = groupMapper.Map(department);

            return result;
        }

        public async Task Delete(long groupId)
        {
            if (groupId < 0)
                throw new ArgumentOutOfRangeException(nameof(groupId));

            var entity = await groupRepository.GetById(groupId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await groupRepository.Delete(entity);
        }

        public async Task<GroupResponse> Get(long groupId)
        {
            if (groupId < 0)
                throw new ArgumentOutOfRangeException(nameof(groupId));

            var group = await groupRepository.GetById(groupId);
            if (group == null)
                throw new ResourceNotFoundException(nameof(group));

            var result = groupMapper.Map(group);

            return result;
        }

        public async Task<IEnumerable<GroupResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new GroupSpecification();

            var people = await groupRepository.List(specification, skip, take);

            var result = groupMapper.MapCollection(people);
            return result;
        }

        public async Task Update(long groupId, UpdateGroupRequest request)
        {
            if (groupId != request.Id)
            {
                throw new ValidationException("group identifier in request and in route is not identical");
            }
            // consider to use validator
            var entity = await groupRepository.GetById(groupId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            groupUpdater.Update(entity, request);

            await groupRepository.Update(entity);
        }
    }
}
