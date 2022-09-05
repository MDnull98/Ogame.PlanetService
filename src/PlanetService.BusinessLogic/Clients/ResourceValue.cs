namespace PlanetService.BusinessLogic.Clients
{
    /// <summary>
    /// Resource mapping model
    /// </summary>
    public class ResourceValue
    {
        /// <summary>Gets or sets the resource type.</summary>
        /// <value>The resource type.</value>
        public ResourceType Type { get; set; }

        /// <summary>Gets or sets the resource value.</summary>
        /// <value>The resource value.</value>
        public double Value { get; set; }
    }

    /// <summary>
    /// Represents types of resources.
    /// </summary>
    public enum ResourceType
    {
        /// <summary>The none.</summary>
        None = 0,

        /// <summary>The metal.</summary>
        Metal = 1,

        /// <summary>The crystal.</summary>
        Crystal = 2,

        /// <summary>The deuterium.</summary>
        Deuterium = 3
    }
}
