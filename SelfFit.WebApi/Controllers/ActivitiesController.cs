using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Application.Features.Activities.Commands;
using SelfFit.Application.Features.Activities.Queries;

namespace SelfFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _mediator.Send(new GetActivitiesQuery());

            return Ok(activities);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(CreateActivityCommand createActivityCommand)
        {
            var addedActivity = await _mediator.Send(createActivityCommand);

            return Ok(addedActivity);
        }
    }
}
