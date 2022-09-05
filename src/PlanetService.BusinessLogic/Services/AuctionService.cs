using Microsoft.Extensions.Logging;
using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.AuctionClient;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using PlanetService.BusinessLogic.Services.Contracts;

namespace PlanetService.BusinessLogic.Services
{
    /// <summary>Auction service.</summary>
    /// <seealso cref="PlanetService.BusinessLogic.Services.Contracts.IAuctionService" />
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionClient _auctionClient;
        private readonly ILogger<AuctionService> _logger;
        private readonly IResourcesClient _resourcesClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionService"/> class.
        /// </summary>
        /// <param name="auctionClient">The auction client.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="resourcesClient">The resources client.</param>
        public AuctionService(IAuctionClient auctionClient, ILogger<AuctionService> logger, IResourcesClient resourcesClient)
        {
            _auctionClient = auctionClient;
            _logger = logger;
            _resourcesClient = resourcesClient;
        }

        /// <summary>
        /// Handlings the bet result.
        /// </summary>
        /// <param name="auctionBid">The auction bid.</param>
        /// <param name="token">The token.</param>
        /// <exception cref="System.ApplicationException">
        /// An attempt to place a bet with Id = {auctionEventId} failed or
        /// Not enough resources to create a bet with Id = {auctionEventId}</exception>
        public async Task HandlingCreationBid(AuctionBidRequest auctionBid, CancellationToken token)
        {
            var resourceUsages = auctionBid.ResourceUsages;
            var auctionEventId = auctionBid.AuctionEventId;

            if (resourceUsages != null &&
                await AreResourcesAvailable(auctionBid.PlanetId, auctionEventId, resourceUsages, token))
            {
                await _resourcesClient.WithdrawResources(auctionBid.PlanetId, resourceUsages, token);

                var eventBidResult = await _auctionClient.CreateEventBid(auctionBid, token);

                if (eventBidResult.BidStatus == BidStatusType.Accepted)
                {
                    _logger.LogInformation("Bid with Id = {auctionEventId} has been placed successfully.", auctionEventId);
                }
                else
                {
                    await _resourcesClient.DepositResources(auctionBid.PlanetId, resourceUsages, token);

                    _logger.LogWarning("An attempt to place a bet with Id = {auctionEventId} failed", auctionEventId);

                    throw new ApplicationException($"An attempt to place a bet with Id = {auctionEventId} failed");
                }
            }
            else
            {
                throw new ApplicationException($"Not enough resources to create a bet with Id = {auctionEventId}");
            }
        }

        /// <summary>
        /// Checks the availability resources.
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="auctionEventId">The auction event identifier.</param>
        /// <param name="bidResourceCost"></param>
        /// <param name="token">The token.</param>
        /// <returns>Bool flag.</returns>
        public async Task<bool> AreResourcesAvailable(Guid planetId, Guid auctionEventId, List<ResourceValue> bidResourceCost, CancellationToken token)
        {
            var planetResources = await _resourcesClient.GetResources(planetId, token);

            foreach (var resource in bidResourceCost)
            {
                var storage = planetResources.FirstOrDefault(x => x.Type == resource.Type);
                if (storage != null && storage.Value < resource.Value)
                {
                    _logger.LogTrace("Not enough resources for placed bed with Id = {auctionEventId}", auctionEventId);

                    return false;
                }
            }

            return true;
        }
    }
}
