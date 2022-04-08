using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Specializations;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IRepository<Specialization> specializationRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly ISpecializationMapper specializationMapper;
        private readonly ISpecializationUpdater specializationUpdater;

        public SpecializationService(IRepository<Specialization> specializationRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            ISpecializationMapper specializationMapper,
            ISpecializationUpdater specializationUpdater)
        {
            this.specializationRepository = specializationRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.specializationMapper = specializationMapper;
            this.specializationUpdater = specializationUpdater;
        }

        public async Task<SpecializationResponse> Create(CreateSpecializationRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));
            // consider to use validator

            var department = specializationMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await specializationRepository.Add(department);
                await transaction.CommitAsync();
            }

            var result = specializationMapper.Map(department);

            return result;
        }

        public async Task Delete(long specializationId)
        {
            if (specializationId < 0)
                throw new ArgumentOutOfRangeException(nameof(specializationId));

            var entity = await specializationRepository.GetById(specializationId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await specializationRepository.Delete(entity);
        }

        public async Task<SpecializationResponse> Get(long specializationId)
        {
            if (specializationId < 0)
                throw new ArgumentOutOfRangeException(nameof(specializationId));

            var specialization = await specializationRepository.GetById(specializationId);
            if (specialization == null)
                throw new ResourceNotFoundException(nameof(specialization));

            var result = specializationMapper.Map(specialization);

            return result;
        }

        public async Task<IEnumerable<SpecializationResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new SpecializationSpecification();

            var specializations = await specializationRepository.List(specification, skip, take);

            var result = specializationMapper.MapCollection(specializations);
            return result;
        }

        public async Task Update(long specializationId, UpdateSpecializationRequest request)
        {
            if (specializationId != request.Id)
            {
                throw new ValidationException("teacher identifier in request and in route is not identical");
            }
            // consider to use validator
            var entity = await specializationRepository.GetById(specializationId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            specializationUpdater.Update(entity, request);

            await specializationRepository.Update(entity);
        }
    }
}
