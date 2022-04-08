using Autofac.Features.Indexed;
using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Students;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Enums;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly IPersonMapper studentMapper;

        private readonly IIndex<PersonDiscriminator, IPersonUpdater> personUpdaters;

        public StudentService(IRepository<Student> studentRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            IIndex<PersonDiscriminator, IPersonMapper> personMappers,
            IIndex<PersonDiscriminator, IPersonUpdater> personUpdaters)
        {
            this.studentRepository = studentRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.personUpdaters = personUpdaters;
            this.studentMapper = personMappers[PersonDiscriminator.Student];
        }

        public async Task<PersonResponse> Create(CreateStudentRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));
            // need add in mapper mapping for request
            var student = (Student)studentMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                // add teacher with teacher card
                await studentRepository.Add(student);
                await transaction.CommitAsync();
            }

            var result = (StudentResponse)studentMapper.Map(student);

            return result;
        }

        public async Task Delete(long studentId)
        {
            if (studentId < 0)
                throw new ArgumentOutOfRangeException(nameof(studentId));

            var entity = await studentRepository.GetById(studentId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await studentRepository.Delete(entity);
        }

        public async Task<PersonResponse> Get(long studentId)
        {
            if (studentId < 0)
                throw new ArgumentOutOfRangeException(nameof(studentId));

            var specification = new StudentSpecificationGetById(studentId);

            var student = await studentRepository.Get(specification);
            if (student == null)
                throw new ResourceNotFoundException(nameof(student));

            var result = (StudentResponse)studentMapper.Map(student);

            return result;
        }

        public async Task<IEnumerable<PersonResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new StudentSpecification();
            // add new specification for getById
            var students = await studentRepository.List(specification, skip, take);

            var result = studentMapper.MapCollection(students).Cast<StudentResponse>().ToList();
            return result;
        }

        public async Task Update(long studentId, UpdateStudentRequest request)
        {
            if (studentId < 0)
                throw new ArgumentOutOfRangeException(nameof(studentId));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // consider to use validator instead this part of code
            if (studentId != request.Id)
            {
                throw new ValidationException("teacher identifier in request and in route is not identical");
            }

            var specification = new StudentSpecificationGetById(studentId);
            var student = await studentRepository.Get(specification);

            if (student == null)
                throw new ResourceNotFoundException(nameof(student));
            var personUpdater = personUpdaters[student.Discriminator] ?? throw new ValidationException("Fucking retard!");

            personUpdater.Update(student, request);

            await studentRepository.Update(student);
        }
    }
}
