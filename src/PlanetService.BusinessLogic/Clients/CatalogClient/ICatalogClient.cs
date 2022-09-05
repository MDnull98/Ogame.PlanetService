namespace PlanetService.BusinessLogic.Clients.CatalogClient
{
    /// <summary>
    /// Catalog client contract
    /// </summary>
    public interface ICatalogClient
    {
        /// <summary>Gets catalog constructions.</summary>
        /// <param name="token">The token.</param>
        /// <returns>Contains the collection of catalog constructions.</returns>
        Task<List<CatalogConstruction>> GetConstructions(CancellationToken token);

        /// <summary>Gets the catalog construction by catalog construction id.</summary>
        /// <param name="constructionId">The catalog construction id.</param>
        /// <param name="token">The token.</param>
        /// <returns>Contains catalog construction model.</returns>
        Task<CatalogConstruction> GetConstructionByType(CatalogConstructionType catalogConstructionType, CancellationToken token);

        /// <summary>Gets the construction level by catalog construction id.</summary>
        /// <param name="catalogConstructionId">The catalog construction id.</param>
        /// <param name="levelValue">The level value.</param>
        /// <param name="token">The token.</param>
        /// <returns>Catalog construction level model.</returns>
        Task<CatalogConstructionLevel> GetConstructionLevelByType(CatalogConstructionType catalogConstructionType, int levelValue, CancellationToken token);
    }
}
