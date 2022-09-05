using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.AuctionClient;

namespace PlanetService.BusinessLogic.Services.Contracts
{
    /// <summary>Abstraction for auction service.</summary>
    public interface IAuctionService
    {
        /// <summary>
        /// Handlings the bet result.
        /// </summary>
        /// <param name="auctionBid">The auction bid.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task HandlingCreationBid(AuctionBidRequest auctionBid, CancellationToken token);

        /// <summary>
        /// Checks the availability resources.
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="auctionEventId">The auction event identifier.</param>
        /// <param name="BidResourceCost">The bid resource cost.</param>
        /// <param name="token">The token.</param>
        /// <returns>Bool flag.</returns>
        Task<bool> AreResourcesAvailable(Guid planetId, Guid auctionEventId, List<ResourceValue> bidResourceCost, CancellationToken token);
    }
}
