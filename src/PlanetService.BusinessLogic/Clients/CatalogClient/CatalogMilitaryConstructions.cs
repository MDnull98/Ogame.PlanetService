namespace PlanetService.BusinessLogic.Clients.CatalogClient
{
    /// <summary>Entity which represent military construction abstraction model on businesses logic layer</summary>
    public class CatalogMilitaryConstructions
    {
        /// <summary>Initializes a new instance of the <see cref="MilitaryConstruction" /> class.</summary>
        public CatalogMilitaryConstructions()
        {
            ResourceCosts = new();
            DependentLevels = new();
        }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string? Name { get; set; }

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image url.</value>
        public string? ImageUrl { get; set; }

        /// <summary>Gets or sets the short description.</summary>
        /// <value>The short description.</value>
        public string? ShortDescription { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string? Description { get; set; }

        /// <summary>Gets or sets the armor.</summary>
        /// <value>The armor.</value>
        public int Armor { get; set; }

        /// <summary>Gets or sets the shield.</summary>
        /// <value>The shield.</value>
        public int Shield { get; set; }

        /// <summary>Gets or sets the attack.</summary>
        /// <value>The attack.</value>
        public int Attack { get; set; }

        /// <summary>Gets or sets the speed.</summary>
        /// <value>The speed.</value>
        public int? Speed { get; set; }

        /// <summary>Gets or sets the delay in seconds.</summary>
        /// <value>The delay in seconds.</value>
        public int DelayInSeconds { get; set; }

        /// <summary>Gets or sets the load capacity.</summary>
        /// <value>The load capacity.</value>
        public int? LoadCapacity { get; set; }

        /// <summary>Gets or sets the fuel consumption.</summary>
        /// <value>The fuel consumption.</value>
        public int? FuelConsumption { get; set; }

        /// <summary>Gets or sets the type of construction.</summary>
        /// <value>The type.</value>
        public CatalogMilitaryConstructionType Type { get; set; }

        /// <summary>Gets or sets the resource cost.</summary>
        /// <value>The resource cost.</value>
        public List<ResourceValue> ResourceCosts { get; set; }

        /// <summary>
        ///   <para>
        /// Gets or sets the Guids of construction levels on which depends entity.
        /// </para>
        /// </summary>
        /// <value>The depends level on.</value>
        public List<Guid> DependentLevels { get; set; }
    }
}
