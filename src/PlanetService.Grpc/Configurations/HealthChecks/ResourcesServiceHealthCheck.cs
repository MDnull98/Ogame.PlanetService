using Grpc.Health.V1;
using Grpc.Net.ClientFactory;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PlanetService.Grpc.Configurations.HealthChecks
{
    public class ResourcesServiceHealthCheck : IHealthCheck
    {
        private readonly GrpcClientFactory _grpcClientFactory;

        public ResourcesServiceHealthCheck(GrpcClientFactory grpcClientFactory)
        {
            _grpcClientFactory = grpcClientFactory;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var client = _grpcClientFactory.CreateClient<Health.HealthClient>(GrpcClientNames.ResourcesHealthCheckClient);
            var response = await client.CheckAsync(new HealthCheckRequest(), cancellationToken: cancellationToken);

            return response.Status == HealthCheckResponse.Types.ServingStatus.Serving
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Unhealthy();
        }
    }
}
