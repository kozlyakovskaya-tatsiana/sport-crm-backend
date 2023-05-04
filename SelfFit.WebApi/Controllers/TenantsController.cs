using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SelfFit.Application.Features.Tenants.Commands;
using SelfFit.Application.Features.Tenants.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelfFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _mediator.Send(new GetTenantsQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTenantCommand createTenantCommand)
        {
            return Ok( await _mediator.Send(createTenantCommand));
        }
    }
}
