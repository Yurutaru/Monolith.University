using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface ISpecializationMapper :
        IMapper<CreateSpecializationRequest, Specialization>,
        IMapper<Specialization, SpecializationResponse>
    {
    }
}
