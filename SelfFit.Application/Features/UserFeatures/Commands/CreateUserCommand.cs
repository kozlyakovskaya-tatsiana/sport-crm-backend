using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool >
        {
            private readonly UserManager<SelfFitUser> _userManager;

            public CreateUserCommandHandler(UserManager<SelfFitUser> userManager)
            {
                _userManager = userManager;
            }
            public async Task<bool> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
            {
                var user = new SelfFitUser
                {
                    Email = createUserCommand.Email,
                    UserName = createUserCommand.Email
                };

                var result = await _userManager.CreateAsync(user, createUserCommand.Password);

                return result.Succeeded;
            }
        }
    }
}
