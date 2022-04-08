using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Teachers;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    // need add attribute to control update, delete method by system administrator
    public class TeachersController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateTeacherRequest request)
        {
            var result = await teacherService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<TeacherResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await teacherService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{teacherId:long}")]
        [ProducesOk(typeof(TeacherResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long teacherId)
        {
            var result = await teacherService.Get(teacherId);
            return Ok(result);
        }

        [HttpPut("{teacherId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long teacherId, UpdateTeacherRequest request)
        {
            await teacherService.Update(teacherId, request);
            return NoContent();
        }

        [HttpDelete("{teacherId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long teacherId)
        {
            await teacherService.Delete(teacherId);
            return NoContent();
        }
    }
}
