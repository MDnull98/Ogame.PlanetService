namespace PlanetService.BusinessLogic.Models
{
    /// <summary>
    /// Data Access construction model
    /// </summary>
    public class PlanetConstruction
    {
        /// <summary>Gets or sets the construction id.</summary>
        /// <value>The construction identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the catalog construction id.</summary>
        /// <value>The catalog construction identifier.</value>
        public Guid CatalogConstructionId { get; set; }

        /// <summary>Gets or sets the construction type.</summary>
        /// <value>The construction type.</value>
        public PlanetConstructionType Type { get; set; }

        /// <summary>Gets or sets the construction level.</summary>
        /// <value>The construction level.</value>
        public int Level { get; set; }

        /// <summary>Gets or sets the planet id.</summary>
        /// <value>The planet identifier.</value>
        public Guid PlanetId { get; set; }

        /// <summary>Gets or sets the coefficient.</summary>
        /// <value>The coefficient.</value>
        public int? Coefficient { get; set; }

        /// <summary>Gets or sets the planet model.</summary>
        /// <value>The planet model.</value>
        public Planet? Planet { get; set; }
    }
}
