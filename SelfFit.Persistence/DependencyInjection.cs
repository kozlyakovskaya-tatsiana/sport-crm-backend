using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Application.Interfaces;
using SelfFit.Domain.Entities;
using SelfFit.Persistence.Services;

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
            services.AddScoped<SelfFitDbContextBase>(provider => provider.GetService<SelfFitDbContext>());

            services.AddScoped<IUserManager, SelfFitUserManager>();

            services.AddIdentityCore<User>(opt =>
            {
                
            }).AddEntityFrameworkStores<SelfFitDbContext>();
        }
    }
}
