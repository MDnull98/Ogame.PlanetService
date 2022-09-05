namespace PlanetService.BusinessLogic.Models
{
    public class PlanetMilitaryConstruction
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the military catalog construction id.</summary>
        /// <value>The military catalog construction identifier.</value>
        public Guid MilitaryCatalogConstructionId { get; set; }

        /// <summary>Gets or sets the military construction type.</summary>
        /// <value>The military construction type.</value>
        public PlanetMilitaryConstructionType Type { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public int Amount { get; set; }

        /// <summary>Gets or sets the planet id.</summary>
        /// <value>The planet identifier.</value>
        public Guid PlanetId { get; set; }

        /// <summary>Gets or sets the planet model.</summary>
        /// <value>The planet model.</value>
        public Planet? Planet { get; set; }
    }
}
