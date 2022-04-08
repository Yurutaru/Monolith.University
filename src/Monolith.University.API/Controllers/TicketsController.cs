using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Tickets;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateTicketRequest request)
        {
            var result = await ticketService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<TicketResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await ticketService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{ticketId:long}")]
        [ProducesOk(typeof(TicketResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long ticketId)
        {
            var result = await ticketService.Get(ticketId);
            return Ok(result);
        }

        [HttpPut("{ticketId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long ticketId, UpdateTicketRequest request)
        {
            await ticketService.Update(ticketId, request);
            return NoContent();
        }

        [HttpDelete("{ticketId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long ticketId)
        {
            await ticketService.Delete(ticketId);
            return NoContent();
        }
    }
}
