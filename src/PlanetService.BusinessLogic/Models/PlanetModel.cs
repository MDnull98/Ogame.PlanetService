namespace PlanetService.BusinessLogic.Models
{
    public class PlanetModel
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string? Name { get; set; }

        /// <summary>Gets or sets the planet diameter.</summary>
        /// <value>The planet diameter.</value>
        public int Diameter { get; set; }

        /// <summary>Gets or sets the planet temperature.</summary>
        /// <value>The planet temperature.</value>
        public int Temperature { get; set; }

        /// <summary>Gets or sets the planet userId.</summary>
        /// <value>The planet userId.</value>
        public int UserId { get; set; }

        /// <summary>Gets or sets the planet place.</summary>
        /// <value>The planet place.</value>
        public string Place { get; set; }
    }
}
