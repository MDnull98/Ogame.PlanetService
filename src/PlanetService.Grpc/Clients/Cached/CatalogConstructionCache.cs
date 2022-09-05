using Microsoft.Extensions.Caching.Memory;
using PlanetService.BusinessLogic.Cache;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.Grpc.Configurations;

namespace PlanetService.Grpc.Clients
{
    /// <summary>Wrapper for interact with IMemoryCache</summary>
    public class CatalogConstructionCache : ICatalogConstructionCache
    {
        private const string s_constructionCacheKey = AppSettings.CatalogConstructionCacheKey;
        private const double s_constructionDeprecatedPerMinute = AppSettings.CatalogConstructionExpirationTimeInMinutes;

        private readonly IMemoryCache _memoryCache;

        /// <summary>Wrapper cache constructor</summary>
        /// <param name="memoryCache">cache</param>
        public CatalogConstructionCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>Clear cache</summary>
        /// <returns>task</returns>
        public Task ClearCatalogConstructionsCache()
        {
            _memoryCache.Remove(s_constructionCacheKey);

            return Task.CompletedTask;
        }

        /// <summary>Get catalog construction cache</summary>
        /// <param name="token">token</param>
        /// <returns>collection of catalog constructions</returns>
        public Task<List<CatalogConstruction>> GetCatalogConstructions(CancellationToken token)
        {
            var constructions = _memoryCache.Get<List<CatalogConstruction>>(s_constructionCacheKey);

            return Task.FromResult(constructions);
        }

        /// <summary>Update catalog constructions cache</summary>
        /// <param name="constructions">collection of constrtuctions</param>
        /// <param name="token">token</param>
        /// <returns>task</returns>
        public Task UpdateCatalogConstructionsCache(List<CatalogConstruction> constructions, CancellationToken token)
        {
            var expirationTime = TimeSpan.FromMinutes(s_constructionDeprecatedPerMinute);

            _memoryCache.Remove(s_constructionCacheKey);
            _memoryCache.Set(s_constructionCacheKey, constructions, expirationTime);

            return Task.CompletedTask;
        }
    }
}
