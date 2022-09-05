using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PlanetService.Grpc.Configurations.HealthChecks;

namespace PlanetService.Grpc.Configurations
{
    public static partial class AppConfigurations
    {
        private static readonly Dictionary<HealthStatus, int> s_statusCodes = new()
        {
            { HealthStatus.Healthy, StatusCodes.Status200OK },
            { HealthStatus.Degraded, StatusCodes.Status200OK },
            { HealthStatus.Unhealthy, StatusCodes.Status503ServiceUnavailable }
        };

        /// <summary>Uses the health probes.</summary>
        /// <param name="app">The application.</param>
        public static void UseHealthProbes(this WebApplication app)
        {
            // In some hosting scenarios, a pair of health checks is used to distinguish two app states:
            // - Readiness indicates if the app is running normally but isn't ready to receive requests.
            // - Liveness indicates if an app has crashed and must be restarted.
            // See: https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
            app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
            {
                Predicate = hc => hc.Tags.Contains(HealthCheckTags.Ready),
                AllowCachingResponses = false,
                ResultStatusCodes = s_statusCodes
            });

            app.MapHealthChecks("/healthz/live", new HealthCheckOptions
            {
                Predicate = hc => !hc.Tags.Contains(HealthCheckTags.Ready),
                AllowCachingResponses = false,
                ResultStatusCodes = s_statusCodes
            });

            app.MapHealthChecks("/healthz.json", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                AllowCachingResponses = false,
                ResultStatusCodes = s_statusCodes
            });
        }
    }
}
