using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;
using Application;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [AllowAnonymous]
        
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new ActivityList.Query()));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult( await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        [ValidateModel]
        [AllowAnonymous]

        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [AllowAnonymous]

        public async Task<IActionResult> EditActivity (Guid id, [FromBody] Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}