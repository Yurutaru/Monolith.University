using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Courses;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    // need add attribute to control create, update, delete method by system administrator
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateCourseRequest request)
        {
            var result = await courseService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<CourseResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await courseService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{courseId:long}")]
        [ProducesOk(typeof(CourseResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long courseId)
        {
            var result = await courseService.Get(courseId);
            return Ok(result);
        }

        [HttpPut("{courseId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long courseId, UpdateCourseRequest request)
        {
            await courseService.Update(courseId, request);
            return NoContent();
        }

        [HttpDelete("{courseId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long courseId)
        {
            await courseService.Delete(courseId);
            return NoContent();
        }
    }
}
