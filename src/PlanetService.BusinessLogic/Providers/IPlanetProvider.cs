using PlanetService.BusinessLogic.Models;

namespace PlanetService.BusinessLogic.Providers
{
    /// <summary>
    /// Planet provider
    /// </summary>
    public interface IPlanetProvider
    {
        /// <summary>Gets planet by id.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token"></param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Planet?> GetById(Guid planetId, CancellationToken token);

        /// <summary>Gets all by user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Collection of planet</returns>
        Task<List<Planet>>? GetAllByUserId(Guid userId, CancellationToken token);
    }
}
