using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;

namespace PlanetService.Grpc.Clients
{
    public class MockBuilderClient : IBuilderClient
    {
        public Task<DateTime> GetEndOfBuildingTimeUtc(Guid planetConstructionId, CancellationToken cancellationToken)
        {
            var random = new Random();
            var seconds = random.Next(-10, 10);

            return Task.FromResult(DateTime.UtcNow.AddSeconds(seconds));
        }

        public Task<DateTime> Build(Guid planetConstructionId, PlanetConstructionType type, TimeSpan executionTime, CancellationToken cancellationToken)
        {
            var date = DateTime.UtcNow.AddSeconds(60);

            return Task.FromResult(date);
        }

        /// <summary>Gets the building queues by planet identifier.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Collection of Building queue.</returns>
        public Task<List<BuilderBuildingQueue>> GetBuildingQueuesByPlanetId(Guid planetId, CancellationToken cancellationToken)
        {
            var buildingQueue = new List<BuilderBuildingQueue>()
            {
                new()
                {
                    ConstructionId = Guid.NewGuid(),
                    ConstructionType = BuilderBuildingQueueType.ConstructioManufacture,
                    ConstructionName = "Metal storage",
                    ConstructionLevel = 2,
                    RemainingTime = DateTime.UtcNow.AddMinutes(5)
                }
            };

            return Task.FromResult(buildingQueue);
        }
    }
}
