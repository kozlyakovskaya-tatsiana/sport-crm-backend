using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Application.Features.Activities.Commands;
using SelfFit.Application.Features.Activities.Queries;
using System.Threading.Tasks;
using SelfFit.Application.Features.SportGroups.Commands;

namespace SelfFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SportGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     var activities = await _mediator.Send(new GetActivitiesQuery());
        //
        //     return Ok(activities);
        // }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSportGroupCommand createSportGroupCommand)
        {
            return Ok( await _mediator.Send(createSportGroupCommand));
        }
    }
}
