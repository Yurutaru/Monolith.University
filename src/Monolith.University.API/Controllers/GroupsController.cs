using Microsoft.AspNetCore.Mvc;
using Monolith.University.API.Swagger;
using Monolith.University.Core.Contracts.Dto.Groups;
using Monolith.University.Core.Services.Interfaces;

namespace Monolith.University.API.Controllers
{
    [Route("api/groups")]
    [ApiController]
    // need add attribute to control create, update, delete method by system administrator
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(CreateGroupRequest request)
        {
            var result = await groupService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<GroupResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await groupService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{groupId:long}")]
        [ProducesOk(typeof(GroupResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(long groupId)
        {
            var result = await groupService.Get(groupId);
            return Ok(result);
        }

        [HttpPut("{groupId:long}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(long groupId, UpdateGroupRequest request)
        {
            await groupService.Update(groupId, request);
            return NoContent();
        }

        [HttpDelete("{groupId:long}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(long groupId)
        {
            await groupService.Delete(groupId);
            return NoContent();
        }
    }
}
