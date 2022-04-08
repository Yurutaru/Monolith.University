using Autofac.Features.Indexed;
using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Teachers;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Teachers;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Enums;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IPersonMapper teacherMapper;

        private readonly IIndex<PersonDiscriminator, IPersonUpdater> personUpdaters;

        public TeacherService(IRepository<Teacher> teacherRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            IIndex<PersonDiscriminator, IPersonMapper> teacherMapper,
            IIndex<PersonDiscriminator, IPersonUpdater> personUpdaters)
        {
            this.teacherRepository = teacherRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.personUpdaters = personUpdaters;
            this.teacherMapper = teacherMapper[PersonDiscriminator.Teacher];
        }
        public async Task<PersonResponse> Create(CreateTeacherRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            var teacher = (Teacher)teacherMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                // add teacher with teacher card
                await teacherRepository.Add(teacher);
                await transaction.CommitAsync();
            }

            var result = (TeacherResponse)teacherMapper.Map(teacher);

            return result;
        }

        public async Task Delete(long teacherId)
        {
            if (teacherId < 0)
                throw new ArgumentOutOfRangeException(nameof(teacherId));

            var entity = await teacherRepository.GetById(teacherId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await teacherRepository.Delete(entity);
        }

        public async Task<IEnumerable<TeacherResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new TeacherSpecification();

            var tags = await teacherRepository.List(specification, skip, take);

            var result = teacherMapper.MapCollection(tags).Cast<TeacherResponse>().ToList();
            return result;
        }

        public async Task<PersonResponse> Get(long teacherId)
        {
            if (teacherId < 0)
                throw new ArgumentOutOfRangeException(nameof(teacherId));

            var teacher = await teacherRepository.GetById(teacherId);
            if (teacher == null)
                throw new ResourceNotFoundException(nameof(teacher));

            var result = (TeacherResponse)teacherMapper.Map(teacher);
    
            return result;
        }

        public async Task Update(long teacherId, UpdateTeacherRequest request)
        {
            if (teacherId < 0)
                throw new ArgumentOutOfRangeException(nameof(teacherId));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // consider to use validator instead this part of code
            if (teacherId != request.Id)
            {
                throw new ValidationException("teacher identifier in request and in route is not identical");
            }

            var entity = await teacherRepository.GetById(teacherId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));
            var personUpdater = personUpdaters[entity.Discriminator] ?? throw new ValidationException("Fucking retard!");
            
            personUpdater.Update(entity, request);

            await teacherRepository.Update(entity);
        }
    }
}
