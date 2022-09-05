using Microsoft.Extensions.DependencyInjection;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Services.Contracts;
using Services = PlanetService.BusinessLogic.Services;

namespace PlanetService.BusinessLogic
{
    /// <summary>Business Dependency registration service</summary>
    public static class BusinessServicesExtensions
    {
        /// <summary>Adds the services to service collection</summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddServiceClients(this IServiceCollection services)
        {
            services.AddScoped<IConstructionService, Services.ConstructionService>();
            services.AddScoped<IPlanetService, Services.PlanetService>();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
