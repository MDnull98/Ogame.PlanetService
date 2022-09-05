using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Providers
{
    /// <summary>
    /// Construction provider
    /// </summary>
    public interface IConstructionProvider
    {
        /// <summary>Gets built constructions by planet id.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<List<PlanetConstruction>> GetBuiltConstructions(Guid planetId, CancellationToken token);

        /// <summary>Gets built construction by construction id.</summary>
        /// <param name="constructionId">The construction id.</param>
        /// <param name="token">The token.</param>
        /// <returns>planet construction</returns>
        Task<PlanetConstruction?> GetBuiltConstructionById(Guid constructionId, CancellationToken token);

        /// <summary>Gets built construction by catalog construction id.</summary>
        /// <param name="type">planet construction type</param>
        /// <param name="planetId">planet id</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// Contains planet construction model if exists, otherwise null</returns>
        Task<PlanetConstruction?> GetBuiltConstructionByPlanetId(PlanetConstructionType type, Guid planetId, CancellationToken token);
    }
}
