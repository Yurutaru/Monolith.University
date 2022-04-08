using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Departments;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    // need add attribute to control create, update, delete method by system administrator
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateDepartmentRequest request)
        {
            var result = await departmentService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<DepartmentResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await departmentService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{departmentId:long}")]
        [ProducesOk(typeof(DepartmentResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long departmentId)
        {
            var result = await departmentService.Get(departmentId);
            return Ok(result);
        }

        [HttpPut("{departmentId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long departmentId, UpdateDepartmentRequest request)
        {
            await departmentService.Update(departmentId, request);
            return NoContent();
        }

        [HttpDelete("{departmentId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long departmentId)
        {
            await departmentService.Delete(departmentId);
            return NoContent();
        }
    }
}
