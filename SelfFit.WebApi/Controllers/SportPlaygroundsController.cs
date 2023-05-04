using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Application.Features.Activities.Commands;
using System.Threading.Tasks;
using System;
using SelfFit.Application.Features.SportPlaygrounds.Commands;
using SelfFit.Application.Features.SportPlaygrounds.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelfFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportPlaygroundsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SportPlaygroundsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetSportPlaygroundsQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSportPlaygroundCommand createSportPlaygroundCommand)
        {
            var addedActivity = await _mediator.Send(createSportPlaygroundCommand);

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
            return Ok(await _mediator.Send(new DeleteSportPlaygroundCommand { Id = id}));
        }
    }
}
