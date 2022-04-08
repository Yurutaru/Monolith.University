using Monolith.University.Core.Contracts.Dto.StudentCards;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface IStudentCardMapper :
        IMapper<StudentCard, StudentCardResponse>
    {
    }
}
