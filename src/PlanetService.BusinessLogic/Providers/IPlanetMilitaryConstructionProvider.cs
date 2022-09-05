using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Providers
{
    /// <summary>Abstraction for planet military construction provider.</summary>
    public interface IPlanetMilitaryConstructionProvider
    {
        /// <summary>Gets the built military constructions.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Collection of military construction.</returns>
        Task<List<PlanetMilitaryConstruction>> GetBuiltMilitaryConstructions(Guid planetId, CancellationToken token);

        /// <summary>Gets the built military construction by identifier.</summary>
        /// <param name="militaryConstructionId">The military construction identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Military construction.</returns>
        Task<PlanetMilitaryConstruction?> GetBuiltMilitaryConstructionById(Guid militaryConstructionId, CancellationToken token);
    }
}
