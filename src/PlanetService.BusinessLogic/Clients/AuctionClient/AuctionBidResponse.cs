
namespace PlanetService.BusinessLogic.Clients.AuctionClient
{
    /// <summary>Auction bid response.</summary>
    public class AuctionBidResponse
    {
        /// <summary>
        /// Gets or sets the bid status.
        /// </summary>
        /// <value>
        /// The bid status.
        /// </value>
        public BidStatusType BidStatus { get; set; }

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
