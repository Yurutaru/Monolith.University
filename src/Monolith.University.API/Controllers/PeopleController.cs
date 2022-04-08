using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : Controller
    {
        private readonly IPersonService peopleService;

        public PeopleController(IPersonService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<PersonResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await peopleService.GetAll(skip, take);
            return Ok(result);
        }
    }
}
