using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Repositories
{
    /// <summary>
    ///  Planet construction repository
    /// </summary>
    public interface IPlanetConstructionRepository
    {
        /// <summary>Adding a new construction</summary>
        /// <param name="planetConstruction">The planet construction model.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Create(PlanetConstruction planetConstruction, CancellationToken token);

        /// <summary>Removes the planet construction by construction id.</summary>
        /// <param name="planetConstructionId">The planet construction id.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreateRange(List<PlanetConstruction> planetConstructions, CancellationToken token);

        /// <summary>Removes the specified planet construction identifier.</summary>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Remove(Guid planetConstructionId, CancellationToken token);
    }
}
