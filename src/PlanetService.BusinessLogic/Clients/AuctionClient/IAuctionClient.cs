namespace PlanetService.BusinessLogic.Clients.AuctionClient
{
    /// <summary>Abstraction for Auction clients service.</summary>
    public interface IAuctionClient
    {
        /// <summary>
        /// Creates the event bid.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returns>Auction bid response.</returns>
        Task<AuctionBidResponse> CreateEventBid(AuctionBidRequest request, CancellationToken token);
    }
}
