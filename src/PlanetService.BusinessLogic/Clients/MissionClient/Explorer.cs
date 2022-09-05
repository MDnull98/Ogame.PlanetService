namespace PlanetService.BusinessLogic.Clients.MissionClient
{
    /// <summary>Explorer model.</summary>
    public class Explorer
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the top score.
        /// </summary>
        /// <value>
        /// The top score.
        /// </value>
        public string? TopScore { get; set; }

        /// <summary>
        /// Gets or sets the sent from planet identifier.
        /// </summary>
        /// <value>
        /// The sent from planet identifier.
        /// </value>
        public Guid SentFromPlanetId { get; set; }

        /// <summary>
        /// Gets or sets the fuel.
        /// </summary>
        /// <value>
        /// The fuel.
        /// </value>
        public int Fuel { get; set; }

        /// <summary>
        /// Gets or sets the hold time in hours.
        /// </summary>
        /// <value>
        /// The hold time in hours.
        /// </value>
        public int HoldTimeInHours { get; set; }

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
    }
}
