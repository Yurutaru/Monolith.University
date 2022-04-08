using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class CourseUpdater : ICourseUpdater
    {
        public void Update(Course domain, UpdateCourseRequest document)
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
            domain.FacultyId = document.FacultyId;
        }
    }
}
