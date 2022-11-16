using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SelfFit.Application.Exceptions;
using SelfFit.Identity.Entities;
using SelfFit.Identity.Features.UserFeatures.Models;
using SelfFit.Identity.Services;
using SelfFit.Identity.Settings;

namespace SelfFit.Identity.Features.UserFeatures.Commands
{
    public class SignInUserCommand : IRequest<SignInUserResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, SignInUserResult>
        {
            private readonly UserManager<SelfFitIdentityUser> _userManager;
            private readonly ITokenService _tokenService;
            private readonly JwtSettings _jwtSettings;

            public SignInUserCommandHandler(
                UserManager<SelfFitIdentityUser> userManager,
                ITokenService tokenService,
                IOptions<JwtSettings> jwtOptions)
            {
                _userManager = userManager;
                _tokenService = tokenService;
                _jwtSettings = jwtOptions.Value;
            }

            public async Task<SignInUserResult> Handle(SignInUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new NotFoundException($"User with email {request.Email} doesn't exist.");
                }
                var isUserAuthenticated = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isUserAuthenticated)
                {
                    throw new ArgumentException("Incorrect input data.");
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                var roleClaims = userRoles.Select(t => new Claim(ClaimTypes.Role, t)).ToList();
                var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("uid", user.Id.ToString()),
                    }
                    .Union(roleClaims);
                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpirationDateTime = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenLifeInMinutes);

                await _userManager.UpdateAsync(user);

                return new SignInUserResult()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    Roles = userRoles,
                    UserId = user.Id,
                    UserName = user.UserName
                };
            }
        }
    }
}
