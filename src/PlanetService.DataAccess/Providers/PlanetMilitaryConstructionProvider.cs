using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;

namespace PlanetService.DataAccess.Providers
{
    /// <summary>Military construction data provider.</summary>
    public class PlanetMilitaryConstructionProvider : IPlanetMilitaryConstructionProvider
    {
        private readonly DbSet<PlanetMilitaryConstruction> _militaryConstructions;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetMilitaryConstructionProvider" /> class.
        /// </summary>
        /// <param name="militaryConstructions">The military constructions set.</param>
        public PlanetMilitaryConstructionProvider(DbSet<PlanetMilitaryConstruction> militaryConstructions)
        {
            _militaryConstructions = militaryConstructions;
        }

        /// <summary>Gets the built military constructions.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Collection of military constructions.</returns>
        public Task<List<PlanetMilitaryConstruction>> GetBuiltMilitaryConstructions(Guid planetId, CancellationToken token)
        {
            return _militaryConstructions
                .AsNoTracking()
                .Where(c => c.PlanetId == planetId)
                .ToListAsync(token);
        }

        /// <summary>Gets the built military construction by identifier.</summary>
        /// <param name="militaryConstructionId">The military construction identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Military construction model.</returns>
        public Task<PlanetMilitaryConstruction?> GetBuiltMilitaryConstructionById(Guid militaryConstructionId, CancellationToken token)
        {
            return _militaryConstructions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == militaryConstructionId, token);
        }
    }
}
