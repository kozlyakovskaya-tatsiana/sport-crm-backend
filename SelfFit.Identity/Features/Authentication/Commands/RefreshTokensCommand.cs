using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SelfFit.Identity.Entities;
using SelfFit.Identity.Models;
using SelfFit.Identity.Services;
using SelfFit.Identity.Settings;

namespace SelfFit.Identity.Features.Authentication.Commands
{
    public class RefreshTokensCommand : IRequest<TokenPair>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public class RefreshTokensCommandHandler : IRequestHandler<RefreshTokensCommand, TokenPair>
        {
            private readonly ITokenService _tokenService;
            private readonly UserManager<SelfFitIdentityUser> _userManager;
            private readonly JwtSettings _jwtSettings;

            public RefreshTokensCommandHandler(
                ITokenService tokenService,
                UserManager<SelfFitIdentityUser> userManager,
                IOptions<JwtSettings> jwtSettings)
            {
                _tokenService = tokenService;
                _userManager = userManager;
                _jwtSettings = jwtSettings.Value;
            }
            public async Task<TokenPair> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
            {
                var principal = _tokenService.GetPrincipalFromToken(request.AccessToken);
                var userName = principal.Identity.Name;

                var user = await _userManager.FindByNameAsync(userName);

                if (user is null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpirationDateTime <=  DateTime.Now)
                    throw new ArgumentException("Invalid data to refresh tokens");

                var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpirationDateTime =
                    DateTimeOffset.UtcNow.AddMinutes(_jwtSettings.RefreshTokenLifeTimeInMinutes);

                return new TokenPair
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                };
            }
        }
    }
}
