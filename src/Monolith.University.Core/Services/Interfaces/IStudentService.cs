using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Students;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task<PersonResponse> Create(CreateStudentRequest request);
        Task Update(long studentId, UpdateStudentRequest request);
        Task<PersonResponse> Get(long studentId);
        Task<IEnumerable<PersonResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long studentId);
    }
}
