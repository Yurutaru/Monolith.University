using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface IDepartmentMapper :
        IMapper<CreateDepartmentRequest, Department>,
        IMapper<Department, DepartmentResponse>
    {
    }
}
