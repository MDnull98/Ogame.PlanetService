using AutoMapper;
using Microsoft.Extensions.Logging;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.BusinessLogic.DataGenerators;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;
using PlanetService.BusinessLogic.Services.Contracts;

namespace PlanetService.BusinessLogic.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IDataContext _dataContext;
        private readonly IPlanetRepository _planetRepository;
        private readonly ICatalogClient _catalogClient;
        private readonly IBuilderClient _builderClient;
        private readonly IPlanetConstructionRepository _planetConstructionRepository;
        private readonly IPlanetProvider _planetProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PlanetService(IDataContext dataContext, IPlanetRepository planetRepository, ICatalogClient catalogClient, IPlanetConstructionRepository planetConstructionRepository, IPlanetProvider planetProvider, IMapper mapper, ILogger<PlanetService> logger, IBuilderClient builderClient)
        {
            _dataContext = dataContext;
            _planetRepository = planetRepository;
            _catalogClient = catalogClient;
            _planetConstructionRepository = planetConstructionRepository;
            _planetProvider = planetProvider;
            _mapper = mapper;
            _logger = logger;
            _builderClient = builderClient;
        }

        public Task<Planet?> GetById(Guid planetId, CancellationToken token)
        {
            if (planetId == Guid.Empty)
            {
                _logger.LogTrace("Planet id is empty");

                throw new ArgumentException("Planet id is empty");
            }

            return _planetProvider.GetById(planetId, token);
        }

        public async Task<Planet> Create(string planetName, Guid userId, CancellationToken token)
        {
            var planet = GeneratePlanetParameters(planetName, userId);
            var planetResult = await _planetRepository.Create(planet, token);
            var constructions = await _catalogClient.GetConstructions(token);
            var planetConstructions = _mapper.Map<List<PlanetConstruction>>(constructions);

            foreach (var construction in planetConstructions)
            {
                construction.PlanetId = planetResult.Id;
                construction.Level = GetLevelForDefaultConstruction(construction.Type);
            }

            await _planetConstructionRepository.CreateRange(planetConstructions, token);
            await _dataContext.SaveChanges(token);

            return planetResult;
        }

        public async Task Remove(Guid planetId, CancellationToken token)
        {
            await _planetRepository.Remove(planetId, token);
            await _dataContext.SaveChanges(token);
        }

        public async Task<PlanetInfo> GetPlanetInfo(Guid planetId, CancellationToken token)
        {
            var planet = await GetById(planetId, token);
            if (planet == null)
            {
                _logger.LogError("Requested planet with Id = {planetId} not found", planetId);

                throw new Exception($"Requested planet with Id = {planetId} not found");
            }

            var builderResult = await _builderClient.GetBuildingQueuesByPlanetId(planetId, token);
            var buildingQueuesList = _mapper.Map<List<BuildingQueue>>(builderResult);

            var planetInfo = new PlanetInfo
            {
                Planet = new Planet
                {
                    Id = planetId,
                    Name = planet.Name,
                    Diameter = planet.Diameter,
                    Temperature = planet.Temperature,
                    Place = planet.Place
                },
                BuildingQueues = buildingQueuesList
            };

            return planetInfo;
        }

        public Task<List<Planet>>? GetPlanetsByUserId(Guid userId, CancellationToken token)
        {
            if (userId == Guid.Empty)
            {
                _logger.LogTrace("User id is empty");

                throw new ArgumentException("User id is empty");
            }

            return _planetProvider.GetAllByUserId(userId, token);
        }

        public async Task<bool> CheckPlanetOwner(Guid planetId, Guid userId, CancellationToken token)
        {
            var planet = await _planetProvider.GetById(planetId, token);

            if (planet != null && planet.UserId == userId)
            {
                return true;
            }
            else
            {
                _logger.LogWarning("Planet with Id = {planetId} was not found", planetId);

                return false;
            }
        }

        private int GetLevelForDefaultConstruction(PlanetConstructionType type)
        {
            return type == PlanetConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY ? 1 : 0;
        }

        private static Planet GeneratePlanetParameters(string planetName, Guid userId)
        {
            return new Planet()
            {
                Name = planetName,
                Diameter = PlanetDataGenerator.GetRandomDiameter(),
                Temperature = PlanetDataGenerator.GetRandomTemperature(),
                Place = PlanetDataGenerator.GetRandomPlace(),
                UserId = userId
            };
        }
    }
}
