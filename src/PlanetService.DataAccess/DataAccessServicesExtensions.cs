using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlanetService.BusinessLogic;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;
using PlanetService.DataAccess.Providers;
using PlanetService.DataAccess.Repositories;

namespace PlanetService.DataAccess
{
    /// <summary>
    ///   Data Access Dependency Injection Extensions
    /// </summary>
    public static class DataAccessServicesExtensions
    {
        /// <summary>Register the sql providers in service collection.</summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IPlanetProvider, PlanetProvider>();
            services.AddScoped<IConstructionProvider, ConstructionProvider>();
            services.AddScoped<IPlanetMilitaryConstructionProvider, PlanetMilitaryConstructionProvider>();

            return services;
        }

        /// <summary>Register the sql repositories in service collection.</summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlanetRepository, PlanetRepository>();
            services.AddScoped<IPlanetConstructionRepository, PlanetConstructionRepository>();
            services.AddScoped<IPlanetMilitaryConstructionRepository, PlanetMilitaryConstructionRepository>();

            return services;
        }

        /// <summary>
        ///   Register the PostgreSQL database context <see cref="PlanetContext"/> class
        ///   and context dependencies in service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddPostgreSqlContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContextPool<PlanetContext>(options);
            services.AddScoped<IDataContext, PlanetDataContext>();
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<PlanetContext>().Set<Planet>());
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<PlanetContext>().Set<PlanetConstruction>());
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<PlanetContext>().Set<PlanetMilitaryConstruction>());

            return services;
        }
    }
}
