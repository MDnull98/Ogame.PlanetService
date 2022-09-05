using PlanetService.BusinessLogic.Clients.AuctionClient;

namespace PlanetService.Grpc.Clients
{
    /// <summary>Mock auction client.</summary>
    /// <seealso cref="PlanetService.BusinessLogic.Clients.AuctionClient.IAuctionClient" />
    public class MockAuctionClient : IAuctionClient
    {
        /// <summary>
        /// Creates the event bid.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// Auction bid response.
        /// </returns>
        public async Task<AuctionBidResponse> CreateEventBid(AuctionBidRequest request, CancellationToken token)
        {
            await Task.Delay(100, token);

            return new AuctionBidResponse
            {
                BidStatus = BidStatusType.Accepted,
                PlanetId = request.PlanetId,
                ResourceUsages = request.ResourceUsages
            };
        }
    }
}
