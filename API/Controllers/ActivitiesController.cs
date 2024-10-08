using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;
using Application;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Application.Core;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // [AllowAnonymous]
        
        [HttpGet]
        public async Task<IActionResult> GetActivities([FromQuery] PagingParams param)
        {
            return HandlePagedResult(await Mediator.Send(new ActivityList.Query { Params = param}));
        }

        [HttpGet("{id}")]
        // [AllowAnonymous]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult( await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        [ValidateModel]
        // [AllowAnonymous]

        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [Authorize(Policy = "IsActivityHost")]
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        // [AllowAnonymous]

        public async Task<IActionResult> EditActivity (Guid id, [FromBody] Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }
        [HttpDelete]
        [Authorize(Policy = "IsActivityHost")]
        [Route("{id:Guid}")]
        // [AllowAnonymous]

        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPost("{id}/attend")]
        // [AllowAnonymous]

        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
        }
    }
}