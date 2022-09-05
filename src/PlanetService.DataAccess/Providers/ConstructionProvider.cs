using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;

namespace PlanetService.DataAccess.Providers
{
    /// <summary>
    /// Construction provider
    /// </summary>
    /// <seealso cref="PlanetService.BusinessLogic.Providers.IConstructionProvider" />
    public class ConstructionProvider : IConstructionProvider
    {
        private readonly DbSet<PlanetConstruction> _constructions;

        /// <summary>Initializes a new instance of the <see cref="ConstructionProvider" /> class.</summary>
        /// <param name="constructions">The constructions set.</param>
        public ConstructionProvider(DbSet<PlanetConstruction> constructions)
        {
            _constructions = constructions;
        }

        /// <summary>Gets built constructions by planet identifier.</summary>
        /// <param name="planetId">The planet id.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains the collection of constructions.</returns>
        public Task<List<PlanetConstruction>> GetBuiltConstructions(Guid planetId, CancellationToken token)
        {
            return _constructions
                .AsNoTracking()
                .Where(c => c.PlanetId == planetId)
                .ToListAsync(token);
        }

        /// <summary>Gets built constructions by construction identifier.</summary>
        /// <param name="constructionId">The identifier.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains the planet construction.</returns>
        public Task<PlanetConstruction?> GetBuiltConstructionById(Guid constructionId, CancellationToken token)
        {
            return _constructions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == constructionId, token);
        }

        /// <summary>Gets built constructions by catalog construction and planet identifiers.</summary>
        /// <param name="calatogConstructionId">The catalog identifier.</param>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains the planet construction if exists, otherwise null.</returns>
        public Task<PlanetConstruction?> GetBuiltConstructionByPlanetId(PlanetConstructionType type, Guid planetId, CancellationToken token)
        {
            return type == PlanetConstructionType.CONSTRUCTION_TYPE_UNSPECIFIED
                ? throw new ArgumentException(nameof(type))
                : _constructions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Type == type && x.PlanetId == planetId, token);
        }
    }
}
