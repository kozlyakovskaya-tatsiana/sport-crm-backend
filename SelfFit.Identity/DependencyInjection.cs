using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SelfFit.Identity.Services;
using SelfFit.Identity.Services.Realization;
using MediatR;
using System.Reflection;
using System.Security.Claims;
using SelfFit.Identity.Authorization;
using SelfFit.Identity.Settings;

namespace SelfFit.Identity
{
    public static class DependencyInjection
    {
        public static void AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.Configure<PasswordSettings>(configuration.GetSection("PasswordSettings"));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<DefaultUserSettings>(configuration.GetSection("DefaultUserSettings"));

            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.ForAdminOnly, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Admin);
                });
                options.AddPolicy(Policy.ForInstructorOnly, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Instructor);
                });
                options.AddPolicy(Policy.ForAdminAndInstructor, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Admin, UserRoles.Instructor);
                });
            });
        }
    }
}
