using Monolith.University.Core.Contracts.Dto.Specializations;

namespace Monolith.University.Core.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<SpecializationResponse> Create(CreateSpecializationRequest request);
        Task Update(long specializationId, UpdateSpecializationRequest request);
        Task<SpecializationResponse> Get(long specializationId);
        Task<IEnumerable<SpecializationResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(long specializationId);
    }
}
