using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Updaters
{
    public class StudentUpdater : PersonUpdater, IPersonUpdater
    {
        public override void Update(Person domain, UpdatePersonRequest document)
        {
            base.Update(domain, document);

            var student = domain as Student;
            var studentRequest = document as UpdateStudentRequest;
            
            if (student == null)
                throw new ArgumentNullException(nameof(student));
            
            if (studentRequest == null)
                throw new ArgumentNullException(nameof(student));

            student.SpecializationId = studentRequest.SpecializationId;
            student.FacultyId = studentRequest.FacultyId;
            student.CourseId = studentRequest.CourseId;
            student.GroupId = studentRequest.GroupId;
        }
    }
}
