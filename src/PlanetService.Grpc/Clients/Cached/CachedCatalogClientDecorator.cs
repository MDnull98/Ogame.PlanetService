using PlanetService.BusinessLogic.Cache;
using PlanetService.BusinessLogic.Clients.CatalogClient;

namespace PlanetService.Grpc.Clients
{
    /// <summary>Catalog cache decorator</summary>
    public class CachedCatalogClientDecorator : ICatalogClient
    {
        private readonly ICatalogConstructionCache _catalogConstructionCache;
        private readonly ICatalogClient _catalogClient;

        /// <summary>Catalog cache decorator constructor</summary>
        /// <param name="catalogClient">point of access for original realization</param>
        /// <param name="catalogConstructionCache">point of access to decorator realization</param>
        public CachedCatalogClientDecorator(ICatalogClient catalogClient, ICatalogConstructionCache catalogConstructionCache)
        {
            _catalogClient = catalogClient;
            _catalogConstructionCache = catalogConstructionCache;
        }

        /// <summary>Get catalog constructions</summary>
        /// <param name="token">token</param>
        /// <returns>collection of catalog constructions</returns>
        public async Task<List<CatalogConstruction>> GetConstructions(CancellationToken token)
        {
            var catalogConstructions = await _catalogConstructionCache.GetCatalogConstructions(token);

            if (catalogConstructions == null)
            {
                catalogConstructions = await _catalogClient.GetConstructions(token);

                await _catalogConstructionCache.UpdateCatalogConstructionsCache(catalogConstructions, token);
            }

            return catalogConstructions;
        }

        /// <summary>Get construction by Id</summary>
        /// <param name="constructionId">construction id</param>
        /// <param name="token">token</param>
        /// <returns>catalog construction model</returns>
        public async Task<CatalogConstruction?> GetConstructionByType(CatalogConstructionType catalogConstructionType, CancellationToken token)
        {
            var catalogConstructions = await _catalogConstructionCache.GetCatalogConstructions(token);

            if (catalogConstructions == null)
            {
                await _catalogClient.GetConstructionByType(catalogConstructionType, token);
            }

            return catalogConstructions.FirstOrDefault(x => x.Type == catalogConstructionType);
        }

        /// <summary>Get construction level model</summary>
        /// <param name="catalogConstructionId">catalog construction id</param>
        /// <param name="levelValue">level value</param>
        /// <param name="token">token</param>
        /// <returns>Catalog construction level model</returns>
        public async Task<CatalogConstructionLevel> GetConstructionLevelByType(CatalogConstructionType catalogConstructionType, int levelValue, CancellationToken token)
        {
            var catalogConstructions = await _catalogConstructionCache.GetCatalogConstructions(token);

            if (catalogConstructions == null)
            {
                await _catalogClient.GetConstructionLevelByType(catalogConstructionType, levelValue, token);
            }

            var construction = catalogConstructions.FirstOrDefault(x => x.Type == catalogConstructionType);
            var levelModel = construction?.Levels.FirstOrDefault(x => x.LevelValue == levelValue);

            return levelModel;
        }
    }
}
