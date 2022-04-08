using Monolith.University.Core.Contracts.Dto.TeacherCard;
using Monolith.University.Core.Contracts.Records;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class TeacherCardMapper : ITeacherCardMapper
    {
        private readonly IFacultyMapper facultyMapper;
        private readonly IDepartmentMapper departmentMapper;

        public TeacherCardMapper(IFacultyMapper facultyMapper, IDepartmentMapper departmentMapper)
        {
            this.facultyMapper = facultyMapper;
            this.departmentMapper = departmentMapper;
        }

        public TeacherCardResponse Map(TeacherCard source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new TeacherCardResponse()
            {
                Id= source.Id,
                Faculty = facultyMapper.Map(source.Faculty ?? new Faculty()),
                Department = departmentMapper.Map(source.Department ?? new Department()),
                StartDate = source.StartDate,
                TeacherCardFullName = new FullNameRecord(source.TeacherCardFullName?.FirstName, source.TeacherCardFullName?.MiddleName, source.TeacherCardFullName?.LastName),
            };
            return result;
        }
    }
}
