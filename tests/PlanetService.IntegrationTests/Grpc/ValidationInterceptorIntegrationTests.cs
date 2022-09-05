using FluentAssertions;
using Grpc.Core;
using PlanetService.Grpc;
using static PlanetService.Grpc.PlanetService;

namespace PlanetService.IntegrationTests.Grpc
{
    public class ValidationInterceptorIntegrationTests : IClassFixture<TestServerFixture>
    {
        private readonly PlanetServiceClient _client;

        public ValidationInterceptorIntegrationTests(TestServerFixture serverFixture)
        {
            _client = new PlanetServiceClient(serverFixture.GrpcChannel);
        }

        [Fact]
        public async Task ValidationInterceptor_Should_ThrowRpcException_When_ValidationFailded()
        {
            // Arrange
            var request = new GetConstructionsRequest()
            {
                PlanetId = "InvalidGuid"
            };

            // Act
            var act = async () => await _client.GetConstructionsAsync(request);

            // Assert
            await act
                .Should()
                .ThrowAsync<RpcException>();
        }
    }
}
