using PlanetService.Grpc.Configurations.HealthChecks;

namespace PlanetService.Grpc.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>Adds the health checks to service collection.</summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>
        ///   The service collection
        /// </returns>
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var healthChecksBuilder = services.AddGrpcHealthChecks();

            healthChecksBuilder.AddNpgSql(configuration.GetConnectionString("PlanetDb"),
                name: HealthCheckTags.PostgreSql,
                tags: new[] { "db", "sql", "planet" });

            healthChecksBuilder.AddCheck<CatalogServiceHealthCheck>("catalog-service", tags: new[]
            {
                HealthCheckTags.Grpc
            });

            healthChecksBuilder.AddCheck<ResourcesServiceHealthCheck>("resources-service", tags: new[]
            {
                HealthCheckTags.Grpc
            });

            healthChecksBuilder.AddCheck<BuilderServiceHealthCheck>("builder-service", tags: new[]
            {
                HealthCheckTags.Grpc
            });

            return healthChecksBuilder.Services;
        }
    }
}
