using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Core.Mappers.Abstractions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Records;

namespace Monolith.University.Core.Mappers
{
    public class StudentMapper : BasePersonMapper<Student, StudentResponse>, IPersonMapper
    {
        private readonly ISpecializationMapper specializationMapper;
        private readonly IStudentCardMapper studentCardMapper;
        private readonly ITicketMapper ticketMapper;
        private readonly IFacultyMapper facultyMapper;
        private readonly ICourseMapper courseMapper;
        private readonly IGroupMapper groupMapper;

        public StudentMapper(
            ISpecializationMapper specializationMapper,
            IStudentCardMapper studentCardMapper,
            ITicketMapper ticketMapper,
            IFacultyMapper facultyMapper,
            ICourseMapper courseMapper,
            IGroupMapper groupMapper)
        {
            this.specializationMapper = specializationMapper;
            this.studentCardMapper = studentCardMapper;
            this.ticketMapper = ticketMapper;
            this.facultyMapper = facultyMapper;
            this.courseMapper = courseMapper;
            this.groupMapper = groupMapper;
        }

        public override Person Map(CreatePersonRequest source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var student = (Student)base.Map(source);
            var studentRequest = source as CreateStudentRequest;

            if (studentRequest == null)
                throw new ArgumentNullException(nameof(studentRequest));

            student.Discriminator = Domain.Enums.PersonDiscriminator.Student;

            var personFullName = source.PersonFullName ?? throw new ArgumentNullException(nameof(source.PersonFullName));

            student.FacultyId = studentRequest.FacultyId;
            student.CourseId = studentRequest.CourseId;
            student.GroupId = studentRequest.GroupId;
            student.SpecializationId = studentRequest.SpecializationId;
            
            student.StudentCard = new StudentCard()
            {
                StudentCardFullName = new FullName(personFullName.FirstName, personFullName.MiddleName, personFullName.LastName),
                StartDate = studentRequest.StartDate,
                EndDate = studentRequest.EndDate,
                FacultyId = studentRequest.FacultyId,
                EducationForm = Domain.Enums.EducationForm.Day
            };

            return student;
        }

        public override PersonResponse Map(Person source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var domain = source as Student;
            if (domain == null)
            {
                throw new ArgumentNullException(nameof(domain));
            }

            var document = (StudentResponse)base.Map(domain);
            document.Tickets = ticketMapper.MapCollection(domain.Tickets).ToList();
            document.Faculty = facultyMapper.Map(domain.Faculty ?? new Faculty());
            document.Course = courseMapper.Map(domain.Course ?? new Course());
            document.Group = groupMapper.Map(domain.Group ?? new Group());
            document.StudentCard = studentCardMapper.Map(domain.StudentCard ?? new StudentCard());
            document.Specialization = specializationMapper.Map(domain.Specialization ?? new Specialization());
            return document;
        }
    }
}
