using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;
using SelfFit.Identity.Entities;
using SelfFit.Identity.Settings;
using SelfFit.Persistence.Repositories;
using SelfFit.Persistence.Seeders;


namespace SelfFit.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SelfFitDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(SelfFitDbContext).Assembly.FullName)));
            services.AddScoped<SelfFitDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISportActivityRepository, SportActivityRepository>();

            services.AddScoped<SelfFitAuthenticationDbSeeder>();

            services.AddIdentity<User, Role>(options =>
                {
                    var passwordSettings = configuration.GetSection("PasswordSettings").Get<PasswordSettings>();
                    options.Password.RequiredLength = passwordSettings.RequireMinLength;
                    options.Password.RequireNonAlphanumeric = passwordSettings.RequireNonAlphanumeric;
                    options.Password.RequireLowercase = passwordSettings.RequireLowercase;
                    options.Password.RequireUppercase = passwordSettings.RequireUppercase;
                    options.Password.RequireDigit = passwordSettings.RequireDigit;
                })
                .AddEntityFrameworkStores<SelfFitDbContext>();
        }
    }
}
