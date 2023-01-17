using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Identity.Features.Authentication.Commands;
using SelfFit.WebApi.Models.User.Requests;

namespace SelfFit.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInRequest signInRequest)
        {
            var signInResult = await _mediator.Send(new SignInUserCommand()
            {
                Email = signInRequest.Email,
                Password = signInRequest.Password
            });

            return Ok(signInResult);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokensRequest refreshTokensRequest)
        {
            var refreshTokensResult = await _mediator.Send(new RefreshTokensCommand()
            {
                AccessToken = refreshTokensRequest.AccessToken,
                RefreshToken = refreshTokensRequest.RefreshToken
            });

            return Ok(refreshTokensResult);
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        // {
        //     var u = await _mediator.Send(new CreateUserCommand()
        //     {
        //         Email = createUserRequest.Email,
        //         Password = createUserRequest.Password
        //     });
        //
        //     return Ok();
        // }
    }
}
