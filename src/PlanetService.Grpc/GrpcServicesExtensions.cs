using Grpc.Health.V1;
using PlanetService.BusinessLogic.Cache;
using PlanetService.BusinessLogic.Clients.AuctionClient;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.BusinessLogic.Clients.MissionClient;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using PlanetService.BusinessLogic.Services;
using PlanetService.BusinessLogic.Services.Contracts;
using PlanetService.Grpc.Clients;
using PlanetService.Grpc.Configurations;
using PlanetService.Grpc.Mapping.Converters;

namespace PlanetService.Grpc
{
    /// <summary>Grpc services dependency injections</summary>
    public static class GrpcServicesExtensions
    {
        /// <summary>Add grpc injections</summary>
        /// <param name="services">services</param>
        /// <returns>service collection</returns>
        public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            var externalServicesRoutingSection = configuration.GetSection("ExternalServicesRouting");

            services.AddSingleton<IResourcesClient, MockResourcesClient>();
            services.AddSingleton<IBuilderClient, MockBuilderClient>();
            services.AddSingleton<IMissionClient, MockMissionClient>();
            services.AddSingleton<IAuctionClient, MockAuctionClient>();
            services.AddScoped<IAuctionService, AuctionService>();

            services.AddScoped<ICatalogClient, MockCatalogClient>();
            services.Decorate<ICatalogClient, CachedCatalogClientDecorator>();

            services.AddSingleton<ICatalogConstructionCache, CatalogConstructionCache>();

            services.AddSingleton<ConstructionTypeConverter>();

            services
                .AddGrpcClient<Health.HealthClient>(GrpcClientNames.BuilderHealthCheckClient, options =>
                {
                    options.Address = new Uri(externalServicesRoutingSection.GetValue<string>("BuilderService"));
                });

            services
                .AddGrpcClient<Health.HealthClient>(GrpcClientNames.CatalogHealthCheckClient, options =>
                {
                    options.Address = new Uri(externalServicesRoutingSection.GetValue<string>("CatalogService"));
                });

            services
                .AddGrpcClient<Health.HealthClient>(GrpcClientNames.ResourcesHealthCheckClient, options =>
                {
                    options.Address = new Uri(externalServicesRoutingSection.GetValue<string>("ResourcesService"));
                });

            return services;
        }
    }
}
