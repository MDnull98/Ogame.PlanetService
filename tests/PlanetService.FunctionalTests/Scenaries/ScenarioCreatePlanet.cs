using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using NScenario;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.FunctionalTests.Adapters;
using PlanetService.Grpc;
using Xunit.Abstractions;
using static PlanetService.Grpc.PlanetService;


namespace PlanetService.FunctionalTests.Scenaries
{
    public class ScenarioCreatePlanet : IClassFixture<TestServerFixture>
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly PlanetServiceClient _planetServiceClient;
        private readonly DateTime _utcNow;

        public ScenarioCreatePlanet(TestServerFixture factory,
            ITestOutputHelper outputHelper)
        {
            _planetServiceClient = new PlanetServiceClient(factory.GrpcChannel);
            _outputHelper = outputHelper;
            _utcNow = DateTime.UtcNow;
        }

        [Fact]
        public async Task CreatePlanet()
        {
            var scenario = TestScenarioFactory.Default(
                new XUnitOutputAdapter(_outputHelper),
                testMethodName: "Create planet.");

            var information = await scenario.Step("Create Planet", async () =>
            {
                var request = new CreatePlanetRequest
                {
                    PlanetName = "Deimos",
                    UserId = Guid.NewGuid().ToString()
                };

                return await _planetServiceClient.CreatePlanetAsync(request);
            });

            information
                .Planet
                .Should()
                .NotBeNull();
        }
    }
}
