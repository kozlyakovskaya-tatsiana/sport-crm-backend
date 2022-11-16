using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using SelfFit.Application;
using SelfFit.Identity;
using SelfFit.Identity.Settings;
using SelfFit.Persistence;
using SelfFit.Persistence.Seeders;
using SelfFit.WebApi.Extensions;

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
            services.AddSwaggerConfiguration();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddAuthenticationAndAuthorization(Configuration);

            services.Configure<PasswordSettings>(Configuration.GetSection("PasswordSettings"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<DefaultUserSettings>(Configuration.GetSection("DefaultUserSettings"));
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            SelfFitAuthenticationDbSeeder seeder)
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
