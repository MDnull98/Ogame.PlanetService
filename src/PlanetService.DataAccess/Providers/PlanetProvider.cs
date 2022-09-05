using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;

namespace PlanetService.DataAccess.Providers
{
    /// <summary>
    /// Planet provider
    /// </summary>
    /// <seealso cref="PlanetService.BusinessLogic.Providers.IPlanetProvider" />
    public class PlanetProvider : IPlanetProvider
    {
        private readonly DbSet<Planet> _planets;

        /// <summary>Initializes a new instance of the <see cref="PlanetProvider" /> class.</summary>
        /// <param name="planets">The planets set.</param>
        public PlanetProvider(DbSet<Planet> planets)
        {
            _planets = planets;
        }

        /// <summary>Gets planet by id.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token"></param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<Planet?> GetById(Guid planetId, CancellationToken token)
        {
            return _planets
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == planetId, token);
        }

        /// <summary>Gets all by user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Collection of planet.</returns>
        public Task<List<Planet>>? GetAllByUserId(Guid userId, CancellationToken token)
        {
            return _planets
                .AsNoTracking()
                .Where(c => c.UserId == userId)
                .ToListAsync(token);
        }
    }
}
