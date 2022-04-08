using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class GroupUpdater : IGroupUpdater
    {
        public void Update(Group domain, UpdateGroupRequest document)
        {
            if (domain is null)
            {
                throw new ArgumentNullException(nameof(domain));
            }

            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            domain.Name = document.Name;
            domain.CourseId = document.CourseId;
            domain.FacultyId = document.FacultyId;
        }
    }
}
