namespace PlanetService.BusinessLogic.Clients.MissionClient
{
    /// <summary>Expedition result model.</summary>
    public class ExpeditionResult
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the planet identifier.
        /// </summary>
        /// <value>
        /// The planet identifier.
        /// </value>
        public Guid PlanetId { get; set; }

        /// <summary>
        /// Gets or sets the sent from planet identifier.
        /// </summary>
        /// <value>
        /// The sent from planet identifier.
        /// </value>
        public Guid SentFromPlanetId { get; set; }

        /// <summary>
        /// Gets or sets the extracted resources.
        /// </summary>
        /// <value>
        /// The extracted resources.
        /// </value>
        public List<ResourceValue>? ExtractedResources { get; set; }

        /// <summary>
        /// Gets or sets the cargo volume.
        /// </summary>
        /// <value>
        /// The cargo volume.
        /// </value>
        public int CargoVolume { get; set; }

        /// <summary>
        /// Gets or sets the resources.
        /// </summary>
        /// <value>
        /// The resources.
        /// </value>
        public List<ResourceValue>? Resources { get; set; }

        /// <summary>
        /// Gets or sets the warships.
        /// </summary>
        /// <value>
        /// The warships.
        /// </value>
        public SpaceshipValue? Warships { get; set; }

        /// <summary>
        /// Gets or sets the civilian ships.
        /// </summary>
        /// <value>
        /// The civilian ships.
        /// </value>
        public SpaceshipValue? CivilianShips { get; set; }

        /// <summary>
        /// Gets or sets the departure date UTC.
        /// </summary>
        /// <value>
        /// The departure date UTC.
        /// </value>
        public DateTime DepartureDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the arrival date UTC.
        /// </summary>
        /// <value>
        /// The arrival date UTC.
        /// </value>
        public DateTime ArrivalDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the return date UTC.
        /// </summary>
        /// <value>
        /// The return date UTC.
        /// </value>
        public DateTime ReturnDateUtc { get; set; }
    }
}
