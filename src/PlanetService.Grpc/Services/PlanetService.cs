using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using PlanetService.BusinessLogic.Clients.AuctionClient;
using PlanetService.BusinessLogic.Clients.MissionClient;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Services.Contracts;
using ServiceModel = PlanetService.BusinessLogic.Clients;

namespace PlanetService.Grpc.Services
{
    /// <summary>Grpc planet service</summary>
    public class PlanetService : Grpc.PlanetService.PlanetServiceBase
    {
        private readonly IMapper _mapper;
        private readonly IConstructionService _constructionService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IPlanetService _planetService;
        private readonly IMissionClient _missionClient;
        private readonly IAuctionClient _auctionClient;
        private readonly IAuctionService _auctionService;
        private readonly IResourcesClient _resourcesClient;
        private readonly ILogger<PlanetService> _logger;

        /// <summary>Planet service constructor</summary>
        /// <param name="mapper">Mapper</param>
        /// <param name="constructionService">Point of access to realization construction service</param>
        public PlanetService(IMapper mapper, IConstructionService constructionService, IDateTimeProvider dateTimeProvider, IPlanetService planetService, IMissionClient missionClient, IAuctionClient auctionClient, IAuctionService auctionService, IResourcesClient resourcesClient, ILogger<PlanetService> logger)
        {
            _mapper = mapper;
            _constructionService = constructionService;
            _dateTimeProvider = dateTimeProvider;
            _missionClient = missionClient;
            _planetService = planetService;
            _auctionClient = auctionClient;
            _auctionService = auctionService;
            _resourcesClient = resourcesClient;
            _logger = logger;
        }

        /// <summary>Get construction method</summary>
        /// <param name="request">Get constructions request model.</param>
        /// <param name="context">Server call context.</param>
        /// <returns>Collection of constructions</returns>
        public override async Task<GetConstructionsResponse> GetConstructions(GetConstructionsRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var planetId = Guid.Parse(request.PlanetId);

            var result = await _constructionService.GetConstructions(planetId, token);
            var constructions = _mapper.Map<List<Construction>>(result);

            var response = new GetConstructionsResponse();
            response.Constructions.AddRange(constructions);

            return response;
        }

        /// <summary>Create construction method</summary>
        /// <param name="request">Create construction request model.</param>
        /// <param name="context">Server call context.</param>
        /// <returns>Construction id and completion time</returns>
        public override async Task<CreateConstructionResponse> CreateConstruction(CreateConstructionRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var planetId = Guid.Parse(request.PlanetId);
            var constructionType = _mapper.Map<PlanetConstructionType>(request.ConstructionType);

            var result = await _constructionService.BuildConstruction(planetId, constructionType, token);
            var time = _dateTimeProvider.NowUtc.AddSeconds(result.TimeInSeconds.TotalSeconds);

            return new CreateConstructionResponse
            {
                ConstructionId = result.PlanetConstructionId.ToString(),
                RemainingTime = Timestamp.FromDateTime(time)
            };
        }

        /// <summary>Gets the planet information.</summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>PlanetInfo response</returns>
        public override async Task<GetPlanetInfoResponse> GetPlanetInfo(GetPlanetInfoRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var planetId = Guid.Parse(request.PlanetId);

            var planetInfo = await _planetService.GetPlanetInfo(planetId, token);
            var result = new GetPlanetInfoResponse
            {
                Planet = _mapper.Map<Planet>(planetInfo.Planet)
            };
            result.BuildingQueues.AddRange((IEnumerable<BuildingQueue>)planetInfo.BuildingQueues);

            return result;
        }

        /// <summary>Gets the planets by user.</summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Planets By User Response.</returns>
        public override async Task<GetPlanetsByUserResponse> GetPlanetsByUser(GetPlanetsByUserRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var userId = Guid.Parse(request.UserId);

            var planets = await _planetService.GetPlanetsByUserId(userId, token);
            var planetsByUser = _mapper.Map<List<Grpc.Planet>>(planets);

            var result = new GetPlanetsByUserResponse();
            result.Planets.AddRange(planetsByUser);

            return result;
        }

        /// <summary>Creates the planet.</summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Create Planet Response.</returns>
        public override async Task<CreatePlanetResponse> CreatePlanet(CreatePlanetRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var userId = Guid.Parse(request.UserId);

            var planet = await _planetService.Create(request.PlanetName, userId, token);

            var result = _mapper.Map<Grpc.Planet>(planet);

            return new CreatePlanetResponse()
            {
                Planet = result
            };
        }

        /// <summary>Creates the expedition.</summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>CreateExpeditionResponse model.</returns>
        public override async Task<CreateExpeditionResponse> CreateExpedition(CreateExpeditionRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var expeditionModel = _mapper.Map<ExpeditionRequest>(request);
            var missionResult = await _missionClient.SendExpedition(expeditionModel, token);

            return new CreateExpeditionResponse();
        }

        /// <summary>Creates the event bid.</summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>CreateEventBidResponse.</returns>
        /// <exception cref="System.ApplicationException">An attempt to place a bet with Id = {auctionEventId} failed</exception>
        public override async Task<CreateEventBidResponse> CreateEventBid(CreateEventBidRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var auctionEventId = Guid.Parse(request.AuctionEventId);
            var userId = Guid.Parse(request.UserId);
            var planetId = Guid.Parse(request.PlanetId);
            var resourceUsages = _mapper.Map<List<ServiceModel.ResourceValue>>(request.ResourceUsages);

            var auctionBid = new AuctionBidRequest
            {
                AuctionEventId = auctionEventId,
                UserId = userId,
                PlanetId = planetId,
                ResourceUsages = resourceUsages
            };

            await _auctionService.HandlingCreationBid(auctionBid, token);

            return new CreateEventBidResponse();
        }
    }
}
