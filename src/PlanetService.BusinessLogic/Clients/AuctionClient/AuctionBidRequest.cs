namespace PlanetService.BusinessLogic.Clients.AuctionClient
{
    /// <summary>Auction bid request.</summary>
    public class AuctionBidRequest
    {
        /// <summary>
        /// Gets or sets the auction event identifier.
        /// </summary>
        /// <value>
        /// The auction event identifier.
        /// </value>
        public Guid AuctionEventId { get; set; }

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
        /// Gets or sets the resource usages.
        /// </summary>
        /// <value>
        /// The resource usages.
        /// </value>
        public List<ResourceValue>? ResourceUsages { get; set; }
    }
}
