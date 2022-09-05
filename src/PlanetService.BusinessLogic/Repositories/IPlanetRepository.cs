using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Repositories
{
    /// <summary>
    ///  Planet repository
    /// </summary>
    public interface IPlanetRepository
    {
        /// <summary>Adding a new planet</summary>
        /// <param name="planet">The planet.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Planet> Create(Planet planet, CancellationToken token);

        /// <summary>Removes the planet by planet id.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        Task Remove(Guid planetId, CancellationToken token);
    }
}
