namespace PlanetService.Grpc.Configurations
{
    public static partial class AppConfigurations
    {
        public static WebApplicationBuilder AddAppSettings(this WebApplicationBuilder appBuilder)
        {
            appBuilder.Host.ConfigureAppConfiguration(config =>
            {
                var prefix = "PlanetSrv_";
                config.AddEnvironmentVariables(prefix);
                config.Build();
            });

            return appBuilder;
        }
    }
}
