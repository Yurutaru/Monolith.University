using Monolith.University.Core.Contracts.Dto.Departments;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentResponse> Create(CreateDepartmentRequest request);
        Task Update(long departmentId, UpdateDepartmentRequest request);
        Task<DepartmentResponse> Get(long departmentId);
        Task<IEnumerable<DepartmentResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long departmentId);
    }
}
