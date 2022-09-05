namespace PlanetService.BusinessLogic.Models
{
    /// <summary>
    /// Remaining time model
    /// </summary>
    public class RemainingTime
    {
        /// <summary>Gets or sets the planet construction id.</summary>
        /// <value>The planet construction identifier.</value>
        public Guid PlanetConstructionId { get; set; }

        /// <summary>Gets or sets the remaining time.</summary>
        /// <value>The remaining time.</value>
        public TimeSpan TimeInSeconds { get; set; }
    }
}
