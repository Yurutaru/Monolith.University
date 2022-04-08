using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Faculties;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/faculties")]
    [ApiController]
    // need add attribute to control create, update, delete method by system administrator
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            this.facultyService = facultyService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateFacultyRequest request)
        {
            var result = await facultyService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<FacultyResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await facultyService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{facultyId:long}")]
        [ProducesOk(typeof(FacultyResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long facultyId)
        {
            var result = await facultyService.Get(facultyId);
            return Ok(result);
        }

        [HttpPut("{facultyId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long facultyId, UpdateFacultyRequest request)
        {
            await facultyService.Update(facultyId, request);
            return NoContent();
        }

        [HttpDelete("{facultyId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long facultyId)
        {
            await facultyService.Delete(facultyId);
            return NoContent();
        }
    }
}
