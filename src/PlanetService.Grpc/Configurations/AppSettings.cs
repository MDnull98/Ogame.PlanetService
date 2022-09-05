namespace PlanetService.Grpc.Configurations
{
    /// <summary>App settings storage</summary>
    public class AppSettings
    {
        /// <summary>catalog construction cache key</summary>
        public const string CatalogConstructionCacheKey = "catalogConstructions";

        /// <summary>catalog construction depreceted time</summary>
        public const double CatalogConstructionExpirationTimeInMinutes = 5;
    }
}
