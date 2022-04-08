using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Teachers;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class TeacherUpdater : PersonUpdater, IPersonUpdater
    {
        public override void Update(Person domain, UpdatePersonRequest document)
        {
            base.Update(domain, document);

            var teacher = domain as Teacher;
            var teacherRequest = document as UpdateTeacherRequest;

            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            if (teacherRequest == null)
                throw new ArgumentNullException(nameof(teacher));

            teacher.FacultyId = teacherRequest.FacultyId;
            teacher.DepartmentId = teacherRequest.DepartmentId;
        }
    }
}
