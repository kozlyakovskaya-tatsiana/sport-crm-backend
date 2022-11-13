using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SelfFit.Application.Interfaces;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool >
        {
            private readonly UserManager<User> _userManager;

            public CreateUserCommandHandler(UserManager<User> userManager)
            {
                _userManager = userManager;
            }
            public async Task<bool> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
            {
                var user = new User
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
