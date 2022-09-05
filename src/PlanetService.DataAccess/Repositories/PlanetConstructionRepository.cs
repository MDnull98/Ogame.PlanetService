using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Repositories;

namespace PlanetService.DataAccess.Repositories
{
    /// <summary>
    /// Planet Construction repository
    /// </summary>
    /// <seealso cref="PlanetService.BusinessLogic.Repositories.IPlanetConstructionRepository" />
    public class PlanetConstructionRepository : IPlanetConstructionRepository
    {
        private readonly DbSet<PlanetConstruction> _planetConstructions;

        /// <summary>Initializes a new instance of the <see cref="PlanetConstructionRepository" /> class.</summary>
        /// <param name="planetConstructions">The planet constructions set.</param>
        public PlanetConstructionRepository(DbSet<PlanetConstruction> planetConstructions)
        {
            _planetConstructions = planetConstructions;
        }

        /// <summary>Adding a new built construction</summary>
        /// <param name="planetConstruction">The planet construction.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task Create(PlanetConstruction planetConstruction, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(planetConstruction, nameof(planetConstruction));

            _planetConstructions.Add(planetConstruction);

            return Task.CompletedTask;
        }

        /// <summary>Adding a new built construction</summary>
        /// <param name="planetConstruction">The planet construction.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task CreateRange(List<PlanetConstruction> planetConstructions, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(planetConstructions, nameof(planetConstructions));

            _planetConstructions.AddRange(planetConstructions);

            return Task.CompletedTask;
        }

        /// <summary>Removes the planet construction by planet construction id.</summary>
        /// <param name="planetConstructionId">The identifier.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        public async Task Remove(Guid planetConstructionId, CancellationToken token)
        {
            var planet = await _planetConstructions.FirstOrDefaultAsync(x => x.Id == planetConstructionId, token);

            if (planet != null)
            {
                _planetConstructions.Remove(planet);
            }
        }
    }
}
