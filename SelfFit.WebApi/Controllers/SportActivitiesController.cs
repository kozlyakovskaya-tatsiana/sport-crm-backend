using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Application.Features.Activities.Commands;
using SelfFit.Application.Features.Activities.Queries;

namespace SelfFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SportActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var activities = await _mediator.Send(new GetActivitiesQuery());

            return Ok(activities);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivityCommand createActivityCommand)
        {
            var addedActivity = await _mediator.Send(createActivityCommand);

            return Ok(addedActivity);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateActivityCommand updateActivityCommand)
        {
            var addedActivity = await _mediator.Send(updateActivityCommand);

            return Ok(addedActivity);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var addedActivity = await _mediator.Send(new DeleteActivityCommand() { ActivityId = id });

            return Ok(addedActivity);
        }
    }
}
