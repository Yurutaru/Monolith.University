using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Students;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    // need add attribute to control update, delete method by system administrator
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateStudentRequest request)
        {
            var result = await studentService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<StudentResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await studentService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{studentId:long}")]
        [ProducesOk(typeof(StudentResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long studentId)
        {
            var result = await studentService.Get(studentId);
            return Ok(result);
        }


        [HttpPut("{studentId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long studentId, UpdateStudentRequest request)
        {
            await studentService.Update(studentId, request);
            return NoContent();
        }

        [HttpDelete("{studentId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long studentId)
        {
            await studentService.Delete(studentId);
            return NoContent();
        }
    }
}
