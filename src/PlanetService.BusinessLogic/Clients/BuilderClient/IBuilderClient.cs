using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Clients.BuilderClient
{
    /// <summary>Point of access for builder client</summary>
    public interface IBuilderClient
    {
        /// <summary>Get endtime</summary>
        /// <param name="planetConstructionId">planet construction id</param>
        /// <param name="cancellationToken">token</param>
        /// <returns>endtime</returns>
        Task<DateTime> GetEndOfBuildingTimeUtc(Guid planetConstructionId, CancellationToken cancellationToken);

        /// <summary>Build construction</summary>
        /// <param name="planetConstructionId">planet construction id</param>
        /// <param name="type">planet construction type</param>
        /// <param name="executionTime">execution time</param>
        /// <param name="cancellationToken">token</param>
        /// <returns>endtime construction building</returns>
        Task<DateTime> Build(Guid planetConstructionId, PlanetConstructionType type, TimeSpan executionTime, CancellationToken cancellationToken);

        /// <summary>Gets the building queues by planet identifier.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Collection of Building queue</returns>
        Task<List<BuilderBuildingQueue>> GetBuildingQueuesByPlanetId(Guid planetId, CancellationToken cancellationToken);
    }
}
