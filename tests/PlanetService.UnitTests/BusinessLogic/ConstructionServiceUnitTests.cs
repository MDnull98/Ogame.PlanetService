using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PlanetService.BusinessLogic;
using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;
using PlanetService.BusinessLogic.Services;
using PlanetService.BusinessLogic.Services.Contracts;
using BLL = PlanetService.BusinessLogic.Services;

namespace PlanetService.UnitTests.BusinessLogic
{
    public class ConstructionServiceUnitTests
    {
        private static readonly CancellationToken s_token = CancellationToken.None;

        private readonly IConstructionService _constructionService;
        private readonly Mock<IConstructionProvider> _mockConstructionProvider;
        private readonly Mock<IPlanetConstructionRepository> _mockplanetConstructionRepository;
        private readonly Mock<ICatalogClient> _mockCatalogClient;
        private readonly Mock<IBuilderClient> _mockBuilderClient;
        private readonly Mock<IResourcesClient> _mockResourcesClient;
        private readonly Mock<IDateTimeProvider> _mockTimeProvider;

        private readonly Mock<IDataContext> _mockDataContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<ConstructionService>> _mockLogger;

        public ConstructionServiceUnitTests()
        {
            _mockConstructionProvider = new Mock<IConstructionProvider>();
            _mockplanetConstructionRepository = new Mock<IPlanetConstructionRepository>();
            _mockCatalogClient = new Mock<ICatalogClient>();
            _mockBuilderClient = new Mock<IBuilderClient>();
            _mockResourcesClient = new Mock<IResourcesClient>();
            _mockDataContext = new Mock<IDataContext>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<ConstructionService>>();
            _mockTimeProvider = new Mock<IDateTimeProvider>();

            _constructionService = new BLL.ConstructionService(
                _mockDataContext.Object,
                _mockConstructionProvider.Object,
                _mockplanetConstructionRepository.Object,
                _mockCatalogClient.Object,
                _mockBuilderClient.Object,
                _mockResourcesClient.Object,
                _mockMapper.Object,
                _mockLogger.Object,
                _mockTimeProvider.Object);
        }

        [Fact]
        public async Task CanAddConstructionToBuilderQueue_Should_Return_True_When_EndTime_IsEqualTo_NowUtc()
        {
            // Arrange
            var nowUtc = DateTime.UtcNow;
            var planetConstructionId = Guid.NewGuid();

            _mockTimeProvider.Setup(x => x.NowUtc).Returns(nowUtc);
            _mockBuilderClient.Setup(x => x.GetEndOfBuildingTimeUtc(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(nowUtc));

            //Act
            var actualResult = await _constructionService.CanAddConstructionToBuilderQueue(planetConstructionId, s_token);

            //Assert
            actualResult.Should()
                        .BeTrue();
        }

        [Fact]
        public async Task CanAddConstructionToBuilderQueue_Should_Return_True_When_EndTime_IsLessThan_NowUtc()
        {
            // Arrange
            var nowUtc = DateTime.UtcNow;
            var planetConstructionId = Guid.NewGuid();

            _mockTimeProvider.Setup(x => x.NowUtc).Returns(nowUtc);
            _mockBuilderClient.Setup(x => x.GetEndOfBuildingTimeUtc(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(nowUtc.AddSeconds(-5)));

            //Act
            var actualResult = await _constructionService.CanAddConstructionToBuilderQueue(planetConstructionId, s_token);

            //Assert
            actualResult.Should()
                        .BeTrue();
        }

        [Fact]
        public async Task CanAddConstructionToBuilderQueue_Should_Return_False_When_EndTime_IsGreaterThan_NowUtc()
        {
            // Arrange
            var nowUtc = DateTime.UtcNow;
            var planetConstructionId = Guid.NewGuid();

            _mockTimeProvider.Setup(x => x.NowUtc).Returns(nowUtc);
            _mockBuilderClient.Setup(x => x.GetEndOfBuildingTimeUtc(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(nowUtc.AddSeconds(5)));

            //Act
            var actualResult = await _constructionService.CanAddConstructionToBuilderQueue(planetConstructionId, s_token);

            //Assert
            actualResult.Should()
                        .BeFalse();
        }

        [Fact]
        public async Task CheckAvailabilityResources_Should_Return_True_When_Enough_Resources()
        {
            // Arrange
            var planetId = Guid.NewGuid();
            var planetConstructionId = Guid.NewGuid();
            var storageResources = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 400 },
                new () { Type = ResourceType.Crystal, Value = 300 },
                new () { Type = ResourceType.Deuterium, Value = 200 },
            };
            var resourceCost = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 300 },
                new () { Type = ResourceType.Crystal, Value = 200 },
                new () { Type = ResourceType.Deuterium, Value = 120 },
            };

            _mockResourcesClient.Setup(x => x.GetResources(It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(storageResources));

            //Act
            var actualResult = await _constructionService.CheckAvailabilityResources(planetId, resourceCost, planetConstructionId, s_token);

            //Assert
            actualResult.Should()
                        .BeTrue();
        }

        [Fact]
        public async Task CheckAvailabilityResources_Should_Return_False_When_Not_Enough_Resources()
        {
            // Arrange
            var planetId = Guid.NewGuid();
            var planetConstructionId = Guid.NewGuid();
            var storageResources = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 300 },
                new () { Type = ResourceType.Crystal, Value = 200 },
                new () { Type = ResourceType.Deuterium, Value = 100 },
            };
            var resourceCost = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 300 },
                new () { Type = ResourceType.Crystal, Value = 200 },
                new () { Type = ResourceType.Deuterium, Value = 120 },
            };

            _mockResourcesClient.Setup(x => x.GetResources(It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(storageResources));

            //Act
            var actualResult = await _constructionService.CheckAvailabilityResources(planetId, resourceCost, planetConstructionId, s_token);

            //Assert
            actualResult.Should()
                        .BeFalse();
        }

        [Fact]
        public async Task CheckAvailabilityResources_Should_Return_True_When_Resources_Storage_IsEqualTo_Resources_Cost()
        {
            // Arrange
            var planetId = Guid.NewGuid();
            var planetConstructionId = Guid.NewGuid();
            var storageResources = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 300 },
                new () { Type = ResourceType.Crystal, Value = 200 },
                new () { Type = ResourceType.Deuterium, Value = 100 },
            };
            var resourceCost = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 300 },
                new () { Type = ResourceType.Crystal, Value = 200 },
                new () { Type = ResourceType.Deuterium, Value = 100 },
            };

            _mockResourcesClient.Setup(x => x.GetResources(It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(storageResources));

            //Act
            var actualResult = await _constructionService.CheckAvailabilityResources(planetId, resourceCost, planetConstructionId, s_token);

            //Assert
            actualResult.Should()
                        .BeTrue();
        }

        [Fact]
        public async Task BuildConstruction_Should_ThrowArgumentException_When_Construction_Level_Not_Found()
        {
            // Arrange
            var planetId = Guid.NewGuid();
            var catalogType = CatalogConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER;
            var planetType = PlanetConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER;
            var constructionId = Guid.NewGuid();
            var resourceCost = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 100 },
                new () { Type = ResourceType.Crystal, Value = 50 },
                new () { Type = ResourceType.Deuterium, Value = 20 },
            };
            var planetConstruction = new PlanetConstruction()
            {
                Id = constructionId,
                CatalogConstructionId = Guid.NewGuid(),
                Coefficient = 100,
                Level = 51,
                PlanetId = planetId,
                Type = planetType
            };
            var emptyBuildingLevel = default(CatalogConstructionLevel);

            _mockCatalogClient
                .Setup(x => x.GetConstructionLevelByType(It.IsAny<CatalogConstructionType>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(emptyBuildingLevel));
            _mockConstructionProvider.Setup(x => x.GetBuiltConstructionByPlanetId(It.IsAny<PlanetConstructionType>(),
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(planetConstruction));

            // Act
            var act = () => _constructionService.BuildConstruction(planetId, planetType, s_token);

            // Assert
            await act.Should().ThrowAsync<Exception>("Construction level cannot be found");
        }

        [Fact]
        public async Task BuildConstruction_Should_Success_When_Remaining_Time_Greater_Then_Zero()
        {
            // Arrange
            var planetId = Guid.NewGuid();
            var catalogType = CatalogConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER;
            var planetType = PlanetConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER;
            var delayInSeconds = 10;
            var constructionId = Guid.NewGuid();
            var resourceCost = new List<ResourceValue>()
            {
                new () { Type = ResourceType.Metal, Value = 100 },
                new () { Type = ResourceType.Crystal, Value = 50 },
                new () { Type = ResourceType.Deuterium, Value = 20 },
            };
            var buildingLevel = new CatalogConstructionLevel()
            {
                Id = Guid.NewGuid(),
                LevelValue = 51,
                ConstructionId = Guid.NewGuid(),
                ResourceCost = resourceCost,
                DelayInSeconds = delayInSeconds,
                EnergyCost = 10
            };
            var planetConstruction = new PlanetConstruction()
            {
                Id = constructionId,
                CatalogConstructionId = Guid.NewGuid(),
                Coefficient = 100,
                Level = 50,
                PlanetId = planetId,
                Type = planetType
            };
            var expectedResult = TimeSpan.Zero;

            _mockConstructionProvider.Setup(x => x.GetBuiltConstructionByPlanetId(It.IsAny<PlanetConstructionType>(),
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(planetConstruction));
            _mockCatalogClient
                .Setup(x => x.GetConstructionLevelByType(It.IsAny<CatalogConstructionType>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(buildingLevel));
            _mockResourcesClient.Setup(x => x.GetResources(It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resourceCost));

            // Act
            var actualResult = await _constructionService.BuildConstruction(planetId, planetType, s_token);

            // Assert
            actualResult
                .TimeInSeconds
                .Should()
                .BeGreaterThan(expectedResult);
        }
    }
}
