using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Domain.Entities;
using SelfFit.Identity;
using SelfFit.Identity.Entities;


namespace SelfFit.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SelfFitDbContextWithIdentity>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(SelfFitDbContextWithIdentity).Assembly.FullName)));
            services.AddScoped<ISelfFitDbContext>(provider => provider.GetService<SelfFitDbContextWithIdentity>());

            services.AddScoped<SelfFitAuthenticationDbSeeder>();

            services
                .AddIdentityCore<SelfFitIdentityUser>()
                .AddRoles<SelfFitRole>()
                .AddEntityFrameworkStores<SelfFitDbContextWithIdentity>();
        }
    }
}
