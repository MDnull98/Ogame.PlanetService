namespace PlanetService.BusinessLogic.Models
{
    /// <summary>
    /// Data Access Planet model
    /// </summary>
    public class Planet
    {
        /// <summary>Initializes a new instance of the <see cref="Planet" /> class.</summary>
        public Planet()
        {
            Constructions = new();
        }

        /// <summary>Gets or sets the planet id.</summary>
        /// <value>The planet identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the planet name.</summary>
        /// <value>The planet name.</value>
        public string? Name { get; set; }

        /// <summary>Gets or sets the planet diameter.</summary>
        /// <value>The planet diameter.</value>
        public int Diameter { get; set; }

        /// <summary>Gets or sets the planet temperature.</summary>
        /// <value>The planet temperature.</value>
        public int Temperature { get; set; }

        /// <summary>Gets or sets the planet userId.</summary>
        /// <value>The planet userId.</value>
        public Guid UserId { get; set; }

        /// <summary>Gets or sets the planet place.</summary>
        /// <value>The planet place.</value>
        public string Place { get; set; }

        /// <summary>Gets or sets the constructions.</summary>
        /// <value>The constructions.</value>
        public List<PlanetConstruction>? Constructions { get; set; }

        /// <summary>Gets or sets the military constructions.</summary>
        /// <value>The military constructions.</value>
        public List<PlanetMilitaryConstruction>? MilitaryConstructions { get; set; }
    }
}
