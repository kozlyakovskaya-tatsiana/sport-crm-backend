using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Application.Features.UserFeatures.Commands;
using SelfFit.WebApi.Models.User.Requests;

namespace SelfFit.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            var u = await _mediator.Send(new CreateUserCommand()
            {
                Email = createUserRequest.Email,
                Password = createUserRequest.Password
            });

            return Ok();
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInRequest signInRequest)
        {
            var signInResult = await _mediator.Send(new SignInUserCommand()
            {
                Email = signInRequest.Email,
                Password = signInRequest.Password
            });

            return Ok(signInResult);
        }
    }
}
