using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Faculties;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IRepository<Faculty> facultyRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly IFacultyMapper facultyMapper;
        private readonly IFacultyUpdater facultyUpdater;

        public FacultyService(IRepository<Faculty> facultyRepository,
            IUnitOfWorkFactory unitOfWorkFactory, 
            IFacultyMapper facultyMapper,
            IFacultyUpdater facultyUpdater)
        {
            this.facultyRepository = facultyRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.facultyMapper = facultyMapper;
            this.facultyUpdater = facultyUpdater;
        }
        public async Task<FacultyResponse> Create(CreateFacultyRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            var department = facultyMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await facultyRepository.Add(department);
                await transaction.CommitAsync();
            }

            var result = facultyMapper.Map(department);

            return result;
        }

        public async Task Delete(long facultyId)
        {
            if (facultyId < 0)
                throw new ArgumentOutOfRangeException(nameof(facultyId));

            var entity = await facultyRepository.GetById(facultyId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await facultyRepository.Delete(entity);
        }

        public async Task<FacultyResponse> Get(long facultyId)
        {
            if (facultyId < 0)
                throw new ArgumentOutOfRangeException(nameof(facultyId));

            var faculty = await facultyRepository.GetById(facultyId);
            if (faculty == null)
                throw new ResourceNotFoundException(nameof(faculty));

            var result = facultyMapper.Map(faculty);

            return result;
        }

        public async Task<IEnumerable<FacultyResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new FacultySpecification();

            var faculties = await facultyRepository.List(specification, skip, take);

            var result = facultyMapper.MapCollection(faculties);
            return result;
        }

        public async Task Update(long facultyId, UpdateFacultyRequest request)
        {
            if (facultyId != request.Id)
            {
                throw new ValidationException("faculty identifier in request and in route is not identical");
            }
            // consider to use validator
            var entity = await facultyRepository.GetById(facultyId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            facultyUpdater.Update(entity, request);

            await facultyRepository.Update(entity);
        }
    }
}
