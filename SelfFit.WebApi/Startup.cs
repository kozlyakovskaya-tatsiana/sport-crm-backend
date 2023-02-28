using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using SelfFit.Application;
using SelfFit.Identity;
using SelfFit.Persistence;
using SelfFit.Persistence.Seeders;
using SelfFit.WebApi.Extensions;
using SelfFit.WebApi.Middleware;
using SelfFit.WebApi.Options;
using SelfFit.WebApi.Validators.Authentication;

namespace SelfFit.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<OriginsOptions>(Configuration.GetSection("Origins"));
            services.AddCors();
            services.AddSwaggerConfiguration();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<SignInRequestValidator>();

            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddAuthenticationAndAuthorization(Configuration);
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            SelfFitAuthenticationDbSeeder seeder,
            IOptions<OriginsOptions> originsOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SelfFit");
                });

                seeder.SeedRolesAndUsersAsync().GetAwaiter().GetResult();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
                .WithOrigins(originsOptions.Value.OriginUrls?.ToArray())
                .AllowAnyHeader()
                .AllowAnyMethod()
                .Build()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
