namespace PlanetService.BusinessLogic.Clients.CatalogClient
{
    /// <summary>
    /// Catalog construction boost mapping model
    /// </summary>
    public class CatalogConstructionBoost
    {
        /// <summary>Gets or sets the catalog construction type.</summary>
        /// <value>The construction type.</value>
        public CatalogConstructionType Type { get; set; }

        /// <summary>Gets or sets the construction value.</summary>
        /// <value>The construction value.</value>
        public double Value { get; set; }
    }
}
