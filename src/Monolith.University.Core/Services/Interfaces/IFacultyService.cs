using Monolith.University.Core.Contracts.Dto.Faculties;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyResponse> Create(CreateFacultyRequest request);
        Task Update(long facultyId, UpdateFacultyRequest request);
        Task<FacultyResponse> Get(long facultyId);
        Task<IEnumerable<FacultyResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long facultyId);
    }
}
