namespace PlanetService.BusinessLogic.Clients.CatalogClient
{
    /// <summary>
    /// Catalog construction mapping model
    /// </summary>
    public class CatalogConstruction
    {
        /// <summary>Initializes a new instance of the <see cref="CatalogConstruction" /> class.</summary>
        public CatalogConstruction()
        {
            DependsLevelOn = new();
            Levels = new();
        }

        /// <summary>Gets or sets the construction id.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the construction name.</summary>
        /// <value>The construction name.</value>
        public string? Name { get; set; }

        /// <summary>Gets or sets the construction image url.</summary>
        /// <value>The image url.</value>
        public string? Image { get; set; }

        /// <summary>Gets or sets the construction short description.</summary>
        /// <value>The short description.</value>
        public string? ShortDescripton { get; set; }

        /// <summary>Gets or sets the construction full description.</summary>
        /// <value>The full description.</value>
        public string? Description { get; set; }

        /// <summary>Gets or sets the construction type.</summary>
        /// <value>The type.</value>
        public CatalogConstructionType Type { get; set; }

        /// <summary>Gets or sets the list of level dependencies.</summary>
        /// <value>The level dependencies.</value>
        public List<Guid> DependsLevelOn { get; set; }

        /// <summary>Gets or sets the list of level models.</summary>
        /// <value>The levels.</value>
        public List<CatalogConstructionLevel> Levels { get; set; }
    }
}
