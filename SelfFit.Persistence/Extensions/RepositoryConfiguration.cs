using Microsoft.Extensions.DependencyInjection;
using SelfFit.Application.Repositories;
using SelfFit.Application;
using SelfFit.Persistence.Repositories;

namespace SelfFit.Persistence.Extensions
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISportActivityRepository, SportActivityRepository>();
            services.AddScoped<ISportPlaygroundRepository, SportPlaygroundRepository>();
            services.AddScoped<ITenantRepository, TenantsRepository>();
            services.AddScoped<ISportGroupRepository, SportGroupRepository>();
        }
    }
}
