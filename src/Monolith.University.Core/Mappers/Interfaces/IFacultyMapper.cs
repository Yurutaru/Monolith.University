using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface IFacultyMapper :
        IMapper<CreateFacultyRequest, Faculty>,
        IMapper<Faculty, FacultyResponse>
    {
    }
}
