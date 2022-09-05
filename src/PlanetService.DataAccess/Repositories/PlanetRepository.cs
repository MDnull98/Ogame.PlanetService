using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Repositories;

namespace PlanetService.DataAccess.Repositories
{
    /// <summary>
    ///   Planet repository
    /// </summary>
    /// <seealso cref="PlanetService.BusinessLogic.Repositories.IPlanetRepository" />
    public class PlanetRepository : IPlanetRepository
    {
        private readonly DbSet<Planet> _planets;

        /// <summary>Initializes a new instance of the <see cref="PlanetRepository" /> class.</summary>
        /// <param name="planets">planets set.</param>
        public PlanetRepository(DbSet<Planet> planets)
        {
            _planets = planets;
        }

        /// <summary>Adding a new planet</summary>
        /// <param name="planet">The planet.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<Planet> Create(Planet planet, CancellationToken token)
        {
            _planets.Add(planet);

            return Task.FromResult(planet);
        }

        /// <summary>Removes the planet by planet id.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        public async Task Remove(Guid planetId, CancellationToken token)
        {
            var planet = await _planets.FirstOrDefaultAsync(x => x.Id == planetId, token);

            if (planet != null)
            {
                _planets.Remove(planet);
            }
        }
    }
}
