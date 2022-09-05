using FluentAssertions;
using NScenario;
using PlanetService.FunctionalTests.Adapters;
using PlanetService.Grpc;
using Xunit.Abstractions;
using static PlanetService.Grpc.PlanetService;


namespace PlanetService.FunctionalTests.Scenaries
{
    public class ScenarioCreateMetalStorageTests : IClassFixture<TestServerFixture>
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly PlanetServiceClient _planetServiceClient;
        private readonly DateTime _utcNow;

        public ScenarioCreateMetalStorageTests(TestServerFixture factory,
            ITestOutputHelper outputHelper)
        {
            _planetServiceClient = new PlanetServiceClient(factory.GrpcChannel);
            _outputHelper = outputHelper;
            _utcNow = DateTime.UtcNow;
        }

        [Fact]
        public async Task CreateMetalStorage()
        {
            var scenario = TestScenarioFactory.Default(
                new XUnitOutputAdapter(_outputHelper),
                testMethodName: "Create metal storage.");
            var constructionType = Grpc.Construction.Types.ConstructionType.MetalStorageProducer;

            var planet = await scenario.Step("Create Planet", async () =>
            {
                var request = new CreatePlanetRequest
                {
                    PlanetName = "Deimos",
                    UserId = Guid.NewGuid().ToString()
                };

                return await _planetServiceClient.CreatePlanetAsync(request);
            });

            var constructions = await scenario.Step("Get all constructions", async () =>
            {
                var request = new GetConstructionsRequest
                {
                    PlanetId = planet.Planet.PlanetId
                };

                return await _planetServiceClient.GetConstructionsAsync(request);
            });

            var construction = constructions.Constructions.FirstOrDefault(x => x.Type == constructionType);

            var result = await scenario.Step("Create metal storage", async () =>
            {
                var request = new CreateConstructionRequest
                {
                    ConstructionType = construction.Type,
                    PlanetId = planet.Planet.PlanetId
                };

                return await _planetServiceClient.CreateConstructionAsync(request);
            });

            var information = result.RemainingTime.ToDateTime().ToUniversalTime();

            information
                .Should()
                .BeAfter(_utcNow);
        }
    }
}
