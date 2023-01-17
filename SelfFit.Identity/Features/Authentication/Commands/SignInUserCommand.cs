using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SelfFit.Application.Exceptions;
using SelfFit.Identity.Entities;
using SelfFit.Identity.Features.Authentication.Models;
using SelfFit.Identity.Services;
using SelfFit.Identity.Settings;

namespace SelfFit.Identity.Features.Authentication.Commands
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
                    throw new ArgumentException("Incorrect input data.");
                }
                var isUserAuthenticated = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isUserAuthenticated)
                {
                    throw new ArgumentException("Incorrect input data.");
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                var roleClaims = userRoles.Select(role => new Claim("role", role));
                var claims = new[]
                {
                    new Claim("userName", user.UserName),
                    new Claim("email", user.Email),
                    new Claim("uid", user.Id.ToString()),
                    new Claim("role", string.Join(";",roleClaims.Select(claim => claim.Value)))
                };
                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpirationDateTime = DateTimeOffset.UtcNow.AddMinutes(_jwtSettings.RefreshTokenLifeTimeInMinutes);

                await _userManager.UpdateAsync(user);

                return new SignInUserResult()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                };
            }
        }
    }
}
