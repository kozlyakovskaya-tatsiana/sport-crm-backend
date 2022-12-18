using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.WebApi.Models.User.Requests;
using System.Threading.Tasks;
using SelfFit.Identity.Features.Authentication.Commands;

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
    }
}
