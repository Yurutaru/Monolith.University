using Monolith.University.Core.Contracts.Dto.TeacherCard;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface ITeacherCardMapper :
        IMapper<TeacherCard, TeacherCardResponse>
    {
    }
}
