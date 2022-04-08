using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Teachers;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<PersonResponse> Create(CreateTeacherRequest request);
        Task Update(long teacherId, UpdateTeacherRequest request);
        Task<PersonResponse> Get(long teacherId);
        Task<IEnumerable<TeacherResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long teacherId);
    }
}
