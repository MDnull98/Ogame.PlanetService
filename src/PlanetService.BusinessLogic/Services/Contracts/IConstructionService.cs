using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Services.Contracts
{
    /// <summary>
    /// Contract which provides access to construction service.
    /// </summary>
    public interface IConstructionService
    {
        /// <summary>Gets constructions.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// Contains planet model if exists, otherwise null</returns>
        Task<List<Construction>> GetConstructions(Guid planetId, CancellationToken token);

        /// <summary>Adding a new built construction.</summary>
        /// <param name="CatalogConstructionId">The catalog construction id.</param>
        /// <param name="planetId">The planet model.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// Contains remaining time.</returns>
        Task<RemainingTime> BuildConstruction(Guid planetId, PlanetConstructionType type, CancellationToken token);

        /// <summary>Check can add construction to builder queue.</summary>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>The bool flag.</returns>
        Task<bool> CanAddConstructionToBuilderQueue(Guid planetConstructionId, CancellationToken token);

        /// <summary>Checks the availability resources.</summary>
        /// <param name="buildingResourceCost">The building resource cost.</param>
        /// <param name="planetResources">The planet resources.</param>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <returns>The bool flag.</returns>
        Task<bool> CheckAvailabilityResources(Guid planetId, List<ResourceValue> buildingResourceCost, Guid planetConstructionId, CancellationToken token);
    }
}
