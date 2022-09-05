namespace PlanetService.BusinessLogic.Clients.MissionClient
{
    /// <summary>Expedition request model.</summary>
    public class ExpeditionRequest
    {
        /// <summary>
        /// Gets or sets the planet identifier.
        /// </summary>
        /// <value>
        /// The planet identifier.
        /// </value>
        public Guid PlanetId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user model.
        /// </value>
        public Explorer? user { get; set; }
    }
}
