using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parkable.Infra.Databases.Contexts;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Infra.Databases.Repositories;

namespace Parkable.Infra.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration);
            services.AddRepositories();
        }

        private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParkableDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
        }
    }
}
