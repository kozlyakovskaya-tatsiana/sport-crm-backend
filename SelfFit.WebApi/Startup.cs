using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using SelfFit.Application;
using SelfFit.Application.Settings;
using SelfFit.Domain.Entities;
using SelfFit.Persistence;

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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();

            services.AddApplication();
            services.AddPersistence(Configuration);

            services.Configure<PasswordSettings>(Configuration.GetSection("PasswordSettings"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<DefaultUserSettings>(Configuration.GetSection("DefaultUserSettings"));

            var set = Configuration.GetSection("JwtSettings").Get<JwtSettings>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SelfFitApi",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            SelfFitDbSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SelfFit");
                });

                seeder.SeedAsync().GetAwaiter().GetResult();
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
