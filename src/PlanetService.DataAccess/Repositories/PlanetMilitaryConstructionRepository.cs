using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Repositories;

namespace PlanetService.DataAccess.Repositories
{
    /// <summary>Planet military construction repository.</summary>
    public class PlanetMilitaryConstructionRepository : IPlanetMilitaryConstructionRepository
    {
        private readonly DbSet<PlanetMilitaryConstruction> _planetMilitaryConstructions;

        /// <summary>Initializes a new instance of the <see cref="PlanetMilitaryConstructionRepository" /> class.</summary>
        /// <param name="planetMilitaryConstructions">The planet military constructions set.</param>
        public PlanetMilitaryConstructionRepository(DbSet<PlanetMilitaryConstruction> planetMilitaryConstructions)
        {
            _planetMilitaryConstructions = planetMilitaryConstructions;
        }

        /// <summary>Creates the specified planet military construction.</summary>
        /// <param name="planetMilitaryConstruction">The planet military construction.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">planetMilitaryConstruction</exception>
        public Task Create(PlanetMilitaryConstruction planetMilitaryConstruction, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(planetMilitaryConstruction, nameof(planetMilitaryConstruction));

            _planetMilitaryConstructions.Add(planetMilitaryConstruction);

            return Task.CompletedTask;
        }

        /// <summary>Creates the range.</summary>
        /// <param name="planetMilitaryConstructions">The planet military constructions.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">planetMilitaryConstructions</exception>
        public Task CreateRange(List<PlanetMilitaryConstruction> planetMilitaryConstructions, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(planetMilitaryConstructions, nameof(planetMilitaryConstructions));

            _planetMilitaryConstructions.AddRange(planetMilitaryConstructions);

            return Task.CompletedTask;
        }

        /// <summary>Removes the specified planet construction identifier.</summary>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <param name="token">The token.</param>
        public async Task Remove(Guid planetConstructionId, CancellationToken token)
        {
            var militaryConstruction = await _planetMilitaryConstructions.FirstOrDefaultAsync(x => x.Id == planetConstructionId, token);

            if (militaryConstruction != null)
            {
                _planetMilitaryConstructions.Remove(militaryConstruction);
            }
        }
    }
}
