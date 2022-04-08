using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class GroupMapper : IGroupMapper
    {
        public Group Map(CreateGroupRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Group()
            {
                Name = source.Name,
                FacultyId = source.FacultyId,
                CourseId = source.CourseId
            };

            return result;
        }

        public GroupResponse Map(Group source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new GroupResponse()
            {
                Id = source.Id,
                Name = source.Name
            };

            return result;
        }
    }
}
