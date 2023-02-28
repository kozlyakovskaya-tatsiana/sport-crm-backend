using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Identity.Features.Authentication.Commands;

namespace SelfFit.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInUserCommand signInUserCommand)
        {
            var tokenPair = await _mediator.Send(signInUserCommand);

            return Ok(tokenPair);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokensCommand refreshTokensCommand)
        {
            var refreshTokensResult = await _mediator.Send(refreshTokensCommand);

            return Ok(refreshTokensResult);
        }
    }
}
