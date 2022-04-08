using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Departments;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly IDepartmentMapper departmentMapper;
        private readonly IDepartmentUpdater departmentUpdater;

        public DepartmentService(IRepository<Department> departmentRepository,
            IUnitOfWorkFactory unitOfWorkFactory, 
            IDepartmentMapper departmentMapper,
            IDepartmentUpdater departmentUpdater)
        {
            this.departmentRepository = departmentRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.departmentMapper = departmentMapper;
            this.departmentUpdater = departmentUpdater;
        }

        public async Task<DepartmentResponse> Create(CreateDepartmentRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            var department = departmentMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await departmentRepository.Add(department);
                await transaction.CommitAsync();
            }

            var result = departmentMapper.Map(department);

            return result;
        }

        public async Task Delete(long departmentId)
        {
            if (departmentId < 0)
                throw new ArgumentOutOfRangeException(nameof(departmentId));

            var entity = await departmentRepository.GetById(departmentId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await departmentRepository.Delete(entity);
        }

        public async Task<DepartmentResponse> Get(long departmentId)
        {
            if (departmentId < 0)
                throw new ArgumentOutOfRangeException(nameof(departmentId));

            var department = await departmentRepository.GetById(departmentId);
            if (department == null)
                throw new ResourceNotFoundException(nameof(department));

            var result = departmentMapper.Map(department);

            return result;
        }

        public async Task<IEnumerable<DepartmentResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new DepartmentSpecification();

            var departments = await departmentRepository.List(specification, skip, take);

            var result = departmentMapper.MapCollection(departments);
            return result;
        }

        public async Task Update(long departmentId, UpdateDepartmentRequest request)
        {
            if (departmentId != request.Id)
            {
                throw new ValidationException("departmentId identifier in request and in route is not identical");
            }
            // consider to use validator
            var entity = await departmentRepository.GetById(departmentId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            departmentUpdater.Update(entity, request);

            await departmentRepository.Update(entity);
        }
    }
}
