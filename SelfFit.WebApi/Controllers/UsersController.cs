using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Application.Features.UserFeatures.Commands;
using SelfFit.WebApi.Models.Requests.User;

namespace SelfFit.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
