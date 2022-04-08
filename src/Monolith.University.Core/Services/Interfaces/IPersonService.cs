using Monolith.University.Core.Contracts.Dto.People;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonResponse>> GetAll(int skip = 0, int take = 100);
    }
}
