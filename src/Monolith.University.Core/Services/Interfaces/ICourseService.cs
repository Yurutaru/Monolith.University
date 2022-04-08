using Monolith.University.Core.Contracts.Dto.Courses;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponse> Create(CreateCourseRequest request);
        Task Update(long courseId, UpdateCourseRequest request);
        Task<CourseResponse> Get(long courseId);
        Task<IEnumerable<CourseResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long courseId);
    }
}
