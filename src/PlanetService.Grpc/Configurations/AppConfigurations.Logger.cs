using Serilog;
using Serilog.Extensions.Hosting;

namespace PlanetService.Grpc.Configurations
{
    /// <summary>Partial application configuration file</summary>
    public static partial class AppConfigurations
    {
        /// <summary>Adds the serilog logger to service collection.</summary>
        /// <param name="appBuilder">The application builder.</param>
        /// <returns>
        ///   The application builder.
        /// </returns>
        public static WebApplicationBuilder AddSerilogLogger(this WebApplicationBuilder appBuilder)
        {
            appBuilder.Host.UseSerilog((_, serviceProvider, config) =>
            {
                config = config.WriteTo.Console();
                config = appBuilder.Environment.IsDevelopment()
                    ? config.MinimumLevel.Debug()
                    : config.MinimumLevel.Warning();
            });

            return appBuilder;
        }
    }
}
