using Grpc.Net.Client;

namespace PlanetService.IntegrationTests
{
    public class TestServerFixture : IDisposable
    {
        private readonly GrpcAppFactory _factory;

        public TestServerFixture()
        {
            _factory = new GrpcAppFactory();
            var client = _factory.CreateDefaultClient(new ResponseVersionHandler());

            GrpcChannel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions
            {
                HttpClient = client
            });
        }

        public GrpcChannel GrpcChannel { get; }

        public void Dispose()
        {
            _factory.Dispose();
        }

        private class ResponseVersionHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
                response.Version = request.Version;
                return response;
            }
        }
    }
}
