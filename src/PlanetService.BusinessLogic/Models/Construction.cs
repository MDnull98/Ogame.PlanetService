using PlanetService.BusinessLogic.Clients.CatalogClient;

namespace PlanetService.BusinessLogic.Models
{
    /// <summary>
    /// Construction model
    /// </summary>
    public class Construction
    {
        /// <summary>Initializes a new instance of the <see cref="Construction" /> class.</summary>
        public Construction()
        {
            CurrentLevel = 0;
            DependsLevelOn = new();
            Levels = new();
        }

        /// <summary>Gets or sets the construction id.</summary>
        /// <value>The identifier.</value>
        public Guid? Id { get; set; }

        /// <summary>Gets or sets the construction name.</summary>
        /// <value>The construction name.</value>
        public string? Name { get; set; }

        /// <summary>Gets or sets the catalog construction id.</summary>
        /// <value>The catalog construction identifier.</value>
        public Guid CatalogConstructionId { get; set; }

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
        public PlanetConstructionType Type { get; set; }

        /// <summary>Gets or sets the list of level dependencies.</summary>
        /// <value>The level dependencies.</value>
        public List<Guid> DependsLevelOn { get; set; }

        /// <summary>Gets or sets the list of level models.</summary>
        /// <value>The levels.</value>
        public List<CatalogConstructionLevel> Levels { get; set; }

        /// <summary>Gets or sets the current construction level.</summary>
        /// <value>The level.</value>
        public int CurrentLevel { get; set; }

        /// <summary>Get state of Id</summary>
        /// <value>state of Id</value>
        public bool IsExisten => Id.HasValue;
    }
}
