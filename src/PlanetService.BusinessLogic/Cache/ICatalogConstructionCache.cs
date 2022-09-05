using PlanetService.BusinessLogic.Clients.CatalogClient;

namespace PlanetService.BusinessLogic.Cache
{
    /// <summary>Point of access to catalog construction cache</summary>
    public interface ICatalogConstructionCache
    {
        /// <summary>Get catalog constructions cache</summary>
        /// <param name="token">token</param>
        /// <returns>Collection of catalog constructions</returns>
        Task<List<CatalogConstruction>> GetCatalogConstructions(CancellationToken token);

        /// <summary>Update catalog construction cache</summary>
        /// <param name="constructions">collection of catalog constructions</param>
        /// <param name="token">token</param>
        /// <returns>Task</returns>
        Task UpdateCatalogConstructionsCache(List<CatalogConstruction> constructions, CancellationToken token);

        /// <summary>Clear current catalog cache</summary>
        /// <returns>Task</returns>
        Task ClearCatalogConstructionsCache();
    }
}
