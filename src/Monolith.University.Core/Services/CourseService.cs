using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Core.Exceptions;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.Courses;
using Monolith.University.Core.Updaters.Interfaces;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly ICourseMapper courseMapper;
        private readonly ICourseUpdater courseUpdater;

        public CourseService(IRepository<Course> courseRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            ICourseMapper courseMapper,
            ICourseUpdater courseUpdater)
        {
            this.courseRepository = courseRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.courseMapper = courseMapper;
            this.courseUpdater = courseUpdater;
        }

        public async Task<CourseResponse> Create(CreateCourseRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            var course = courseMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await courseRepository.Add(course);
                await transaction.CommitAsync();
            }

            var result = courseMapper.Map(course);

            return result;
        }

        public async Task Delete(long courseId)
        {
            if (courseId < 0)
                throw new ArgumentOutOfRangeException(nameof(courseId));

            var entity = await courseRepository.GetById(courseId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await courseRepository.Delete(entity);
        }

        public async Task<CourseResponse> Get(long courseId)
        {
            if (courseId < 0)
                throw new ArgumentOutOfRangeException(nameof(courseId));

            var course = await courseRepository.GetById(courseId);
            if (course == null)
                throw new ResourceNotFoundException(nameof(course));

            var result = courseMapper.Map(course);

            return result;
        }

        public async Task<IEnumerable<CourseResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new CourseSpecification();

            var courses = await courseRepository.List(specification, skip, take);

            var result = courseMapper.MapCollection(courses);
            return result;
        }

        public async Task Update(long courseId, UpdateCourseRequest request)
        {
            if (courseId != request.Id)
            {
                throw new ValidationException("course identifier in request and in route is not identical");
            }

            // consider to use validator

            var entity = await courseRepository.GetById(courseId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            courseUpdater.Update(entity, request);

            await courseRepository.Update(entity);

        }
    }
}
