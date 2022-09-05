using AutoMapper;
using Microsoft.Extensions.Logging;
using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;
using PlanetService.BusinessLogic.Services.Contracts;

namespace PlanetService.BusinessLogic.Services
{
    /// <summary>Construction Service</summary>
    public class ConstructionService : IConstructionService
    {
        private readonly IDataContext _dataContext;
        private readonly IConstructionProvider _constructionProvider;
        private readonly IPlanetConstructionRepository _planetConstructionRepository;
        private readonly ICatalogClient _catalogServiceClient;
        private readonly IBuilderClient _builderServiceClient;
        private readonly IResourcesClient _resourcesServiceClient;
        private readonly IMapper _mapper;
        private readonly ILogger<ConstructionService> _logger;
        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>Construction service constructor</summary>
        /// <param name="dataContext">context</param>
        /// <param name="constructionProvider">planet construction provider</param>
        /// <param name="planetConstructionRepository">planet construction repository</param>
        /// <param name="catalogServiceClient">point of access to catalog service</param>
        /// <param name="builderServiceClient">point of access to builder service</param>
        /// <param name="resourcesServiceClient">point of access to resources service</param>
        /// <param name="mapper">mapper</param>
        /// <param name="logger">logger</param>
        /// <param name="dateTimeProvider">dateTime provider</param>
        public ConstructionService(IDataContext dataContext,
            IConstructionProvider constructionProvider,
            IPlanetConstructionRepository planetConstructionRepository,
            ICatalogClient catalogServiceClient,
            IBuilderClient builderServiceClient,
            IResourcesClient resourcesServiceClient,
            IMapper mapper,
            ILogger<ConstructionService> logger,
            IDateTimeProvider dateTimeProvider)
        {
            _dataContext = dataContext;
            _constructionProvider = constructionProvider;
            _planetConstructionRepository = planetConstructionRepository;
            _catalogServiceClient = catalogServiceClient;
            _builderServiceClient = builderServiceClient;
            _resourcesServiceClient = resourcesServiceClient;
            _mapper = mapper;
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>Get detail constructions by planet Id</summary>
        /// <param name="planetId">planet id</param>
        /// <param name="token">token</param>
        /// <returns>collection of constructions</returns>
        public async Task<List<Construction>> GetConstructions(Guid planetId, CancellationToken token)
        {
            var catalogConstructions = await _catalogServiceClient.GetConstructions(token);
            var constructions = _mapper.Map<List<Construction>>(catalogConstructions);

            var constructionResult = await SetBuildingLevel(planetId, constructions, token);

            return constructionResult;
        }

        /// <summary>Create construction for planet</summary>
        /// <param name="catalogConstructionId">catalog construction id</param>
        /// <param name="planetId">planet id</param>
        /// <param name="type">type</param>
        /// <param name="token">token</param>
        /// <returns>remaining time</returns>
        public async Task<RemainingTime> BuildConstruction(Guid planetId, PlanetConstructionType type, CancellationToken token)
        {
            var planetConstruction = await _constructionProvider.GetBuiltConstructionByPlanetId(type, planetId, token);
            var improvedBuildingLevelValue = planetConstruction.Level + 1;
            var catalogType = _mapper.Map<CatalogConstructionType>(type);
            var improvedBuildingLevel = await _catalogServiceClient.GetConstructionLevelByType(catalogType, improvedBuildingLevelValue, token);

            if (improvedBuildingLevel != null &&
                await CanAddConstructionToBuilderQueue(planetConstruction.Id, token) &&
                await CheckAvailabilityResources(planetId, improvedBuildingLevel.ResourceCost, planetConstruction.Id, token) &&
                await HaveEnoughTechnologies())
            {
                var delayInSeconds = TimeSpan.FromSeconds(improvedBuildingLevel.DelayInSeconds);
                await _resourcesServiceClient.WithdrawResources(planetId, improvedBuildingLevel.ResourceCost, token);
                await _builderServiceClient.Build(planetConstruction.Id, type, delayInSeconds, token);

                return new RemainingTime
                {
                    PlanetConstructionId = planetConstruction.Id,
                    TimeInSeconds = delayInSeconds
                };
            }

            throw new Exception($"Build of the construction could not be completed");
        }

        /// <summary>Determines whether this instance the specified planet construction identifier.</summary>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns><c>true</c> if this instance [can add construction to builder queue] the specified planet construction identifier; otherwise, <c>false</c>.</returns>
        public async Task<bool> CanAddConstructionToBuilderQueue(Guid planetConstructionId, CancellationToken token)
        {
            var endOfBuildingTimeUtc = await _builderServiceClient.GetEndOfBuildingTimeUtc(planetConstructionId, token);
            if (endOfBuildingTimeUtc > _dateTimeProvider.NowUtc)
            {
                _logger.LogTrace("Until the completion of the building with Id {planetConstructionId} will be complete at {endOfBuildingTimeUtc}",
                    planetConstructionId,
                    endOfBuildingTimeUtc);

                return false;
            }

            return true;
        }

        /// <summary>Checks the availability resources.</summary>
        /// <param name="buildingResourceCost">The building resource cost.</param>
        /// <param name="planetResources">The planet resources.</param>
        /// <param name="planetConstructionId">The planet construction identifier.</param>
        /// <returns>bool flag</returns>
        public async Task<bool> CheckAvailabilityResources(Guid planetId, List<ResourceValue> buildingResourceCost, Guid planetConstructionId, CancellationToken token)
        {
            var planetResources = await _resourcesServiceClient.GetResources(planetId, token);

            foreach (var resourceCost in buildingResourceCost)
            {
                var storage = planetResources.FirstOrDefault(x => x.Type == resourceCost.Type);
                if (storage != null && storage.Value < resourceCost.Value)
                {
                    _logger.LogTrace("Not enough resources for build constructionId = {planetConstructionId}", planetConstructionId);

                    return false;
                }
            }

            return true;
        }

        private Task<bool> HaveEnoughTechnologies()
        {
            return Task.FromResult(true);
        }

        private async Task<List<Construction>> SetBuildingLevel(Guid planetId, List<Construction> constructions, CancellationToken token)
        {
            var builtConstructions = await _constructionProvider.GetBuiltConstructions(planetId, token);
            foreach (var construction in constructions)
            {
                var item = builtConstructions.FirstOrDefault(c => c.CatalogConstructionId == construction.Id);

                if (item != null)
                {
                    construction.Id = item.Id;
                    construction.CurrentLevel = item?.Level ?? 0;
                }
            }

            return constructions;
        }
    }
}
