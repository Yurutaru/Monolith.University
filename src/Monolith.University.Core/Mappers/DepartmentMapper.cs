using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Domain.Entities;

namespace Monolith.University.Core.Mappers
{
    public class DepartmentMapper : IDepartmentMapper
    {
        private readonly IFacultyMapper facultyMapper;

        public DepartmentMapper(IFacultyMapper facultyMapper)
        {
            this.facultyMapper = facultyMapper;
        }

        public Department Map(CreateDepartmentRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Department()
            {
                Name = source.Name,
                FacultyId = source.FacultyId
            };

            return result;
        }

        public DepartmentResponse Map(Department source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new DepartmentResponse()
            {
                Id = source.Id,
                Name = source.Name,
                Faculty = facultyMapper.Map(source.Faculty ?? new Faculty())
            };

            return result;
        }
    }
}
