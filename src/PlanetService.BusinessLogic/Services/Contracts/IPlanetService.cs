using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Services.Contracts
{
    /// <summary>
    /// Contract which provides access to planet service.
    /// </summary>
    public interface IPlanetService
    {
        /// <summary>Gets planet by id.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token"></param>
        /// <returns>A task that represents the asynchronous operation.
        /// Contains planet model if exists, otherwise null</returns>
        Task<Planet?> GetById(Guid planetId, CancellationToken token);

        /// <summary>Adding a new planet.</summary>
        /// <param name="planet">The planet model.</param>
        /// <param name="token">The token.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// Contains planet model.</returns>
        Task<Planet> Create(string planetName, Guid userId, CancellationToken token);

        /// <summary>Gets the planet information.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Planet info.</returns>
        Task<PlanetInfo> GetPlanetInfo(Guid planetId, CancellationToken token);

        /// <summary>Gets the planets by user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Collection of planet.</returns>
        Task<List<Planet>>? GetPlanetsByUserId(Guid userId, CancellationToken token);

        /// <summary>Checks the planet owner.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Bool flag.</returns>
        Task<bool> CheckPlanetOwner(Guid planetId, Guid userId, CancellationToken token);
    }
}
