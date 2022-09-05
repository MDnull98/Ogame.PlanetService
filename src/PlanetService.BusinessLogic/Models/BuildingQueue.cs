namespace PlanetService.BusinessLogic.Models
{
    /// <summary>Building queue class</summary>
    public class BuildingQueue
    {
        /// <summary>
        /// Gets or sets the construction identifier.
        /// </summary>
        /// <value>
        /// The construction identifier.
        /// </value>
        public Guid ConstructionId { get; set; }

        /// <summary>
        /// Gets or sets the type of the construction.
        /// </summary>
        /// <value>
        /// The type of the construction.
        /// </value>
        public BuildingQueueType ConstructionType { get; set; }

        /// <summary>
        /// Gets or sets the name of the construction.
        /// </summary>
        /// <value>
        /// The name of the construction.
        /// </value>
        public string ConstructionName { get; set; }

        /// <summary>
        /// Gets or sets the construction level.
        /// </summary>
        /// <value>
        /// The construction level.
        /// </value>
        public int? ConstructionLevel { get; set; }

        /// <summary>
        /// Gets or sets the remaining time.
        /// </summary>
        /// <value>
        /// The remaining time.
        /// </value>
        public DateTime? RemainingTime { get; set; }
    }

    /// <summary>Building Queue type enum</summary>
    public enum BuildingQueueType
    {
        /// <summary>
        /// The unspecified
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The constructio manufacture
        /// </summary>
        ConstructioManufacture = 1,

        /// <summary>
        /// The construction research
        /// </summary>
        ConstructionResearch = 2,

        /// <summary>
        /// The construction military
        /// </summary>
        ConstructionMilitary = 3
    }
}
