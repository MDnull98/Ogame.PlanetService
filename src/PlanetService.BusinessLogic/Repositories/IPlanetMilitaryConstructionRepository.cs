using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Repositories
{
    /// <summary>Abstraction for planet military construction repository.</summary>
    public interface IPlanetMilitaryConstructionRepository
    {
        /// <summary>Creates the specified planet military construction.</summary>
        /// <param name="planetMilitaryConstruction">The planet military construction.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task Create(PlanetMilitaryConstruction planetMilitaryConstruction, CancellationToken token);

        /// <summary>Creates the range.</summary>
        /// <param name="planetMilitaryConstructions">The planet military constructions.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task CreateRange(List<PlanetMilitaryConstruction> planetMilitaryConstructions, CancellationToken token);

        /// <summary>Removes the specified planet construction identifier.</summary>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task Remove(Guid planetConstructionId, CancellationToken token);
    }
}
