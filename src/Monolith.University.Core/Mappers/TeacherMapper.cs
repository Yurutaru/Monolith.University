using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Teachers;
using Monolith.University.Core.Mappers.Abstractions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Records;

namespace Monolith.University.Core.Mappers
{
    public class TeacherMapper : BasePersonMapper<Teacher, TeacherResponse>, IPersonMapper
    {
        private readonly ITeacherCardMapper teacherCardMapper;

        public TeacherMapper(ITeacherCardMapper teacherCardMapper)
        {
            this.teacherCardMapper = teacherCardMapper;
        }

        public override Person Map(CreatePersonRequest source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            var teacher = (Teacher)base.Map(source);
            var teacherRequest = source as CreateTeacherRequest;

            if (teacherRequest == null)
                throw new ArgumentNullException(nameof(teacherRequest));

            teacher.Discriminator = Domain.Enums.PersonDiscriminator.Teacher;
           
            var personFullName = source.PersonFullName ?? throw new ArgumentNullException(nameof(source.PersonFullName));
            teacher.TeacherCard = new TeacherCard()
            {
                TeacherCardFullName = new FullName(personFullName.FirstName, personFullName.MiddleName, personFullName.LastName),
                StartDate = teacherRequest.StartDate,
                DepartmentId = teacherRequest.DepartmentId,
                FacultyId = teacherRequest.FacultyId,
            };

            return teacher;
        }

        public override PersonResponse Map(Person source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var domain = source as Teacher;
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));

            var document = (TeacherResponse)base.Map(source);
            document.Discriminator = source.Discriminator.ToString();
            document.TeacherCard = teacherCardMapper.Map(domain.TeacherCard ?? new TeacherCard());

            return document;
        }
    }
}
