using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters.Interfaces
{
    public interface ICourseUpdater
    {
        void Update(Course domain, UpdateCourseRequest document);
    }
}
