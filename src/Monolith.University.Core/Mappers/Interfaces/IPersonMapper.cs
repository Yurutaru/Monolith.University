using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Mappers.Interfaces
{
    public interface IPersonMapper :
        IMapper<CreatePersonRequest, Person>,
        IMapper<Person, PersonResponse>
    {
    }
}
