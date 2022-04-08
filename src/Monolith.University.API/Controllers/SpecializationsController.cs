using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Specializations;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/specializations")]
    [ApiController]
    // need add attribute to control create, update, delete method by system administrator
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationService specializationService;

        public SpecializationsController(ISpecializationService specializationService)
        {
            this.specializationService = specializationService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateSpecializationRequest request)
        {
            var result = await specializationService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<SpecializationResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await specializationService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{specializationId:long}")]
        [ProducesOk(typeof(SpecializationResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long specializationId)
        {
            var result = await specializationService.Get(specializationId);
            return Ok(result);
        }

        [HttpPut("{specializationId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long specializationId, UpdateSpecializationRequest request)
        {
            await specializationService.Update(specializationId, request);
            return NoContent();
        }

        [HttpDelete("{specializationId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long specializationId)
        {
            await specializationService.Delete(specializationId);
            return NoContent();
        }
    }
}
