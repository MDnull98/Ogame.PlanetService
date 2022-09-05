using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PlanetService.BusinessLogic;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;
using PlanetService.BusinessLogic.Services.Contracts;
using BLL = PlanetService.BusinessLogic.Services;

namespace PlanetService.UnitTests.BusinessLogic
{
    public class PlanetServiceUnitTests
    {
        private static readonly CancellationToken s_token = CancellationToken.None;

        private readonly IPlanetService _planetService;

        private readonly Mock<IPlanetProvider> _mockPlanetProvider;
        private readonly Mock<IPlanetRepository> _mockPlanetRepository;
        private readonly Mock<IPlanetConstructionRepository> _mockplanetConstructionRepository;

        private readonly Mock<ICatalogClient> _mockCatalogClient;
        private readonly Mock<IBuilderClient> _mockBuilderClient;
        private readonly Mock<IResourcesClient> _mockResourcesClient;

        private readonly Mock<IDataContext> _mockDataContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<BLL.PlanetService>> _mockLogger;

        public PlanetServiceUnitTests()
        {
            _mockCatalogClient = new Mock<ICatalogClient>();
            _mockBuilderClient = new Mock<IBuilderClient>();
            _mockResourcesClient = new Mock<IResourcesClient>();
            _mockplanetConstructionRepository = new Mock<IPlanetConstructionRepository>();
            _mockPlanetProvider = new();
            _mockDataContext = new Mock<IDataContext>();
            _mockPlanetRepository = new Mock<IPlanetRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<BLL.PlanetService>>();
            _planetService = new BLL.PlanetService(_mockDataContext.Object, _mockPlanetRepository.Object, _mockCatalogClient.Object, _mockplanetConstructionRepository.Object, _mockPlanetProvider.Object, _mockMapper.Object, _mockLogger.Object, _mockBuilderClient.Object);
        }

        [Fact]
        public async Task GetById_Should_ThrowArgumentException_WhenPlanetIdIsEmpty()
        {
            // Arrange
            var planetId = Guid.Empty;

            // Act
            var act = () => _planetService.GetById(planetId, s_token);

            // Assert
            await act.Should()
                .ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task GetById_Should_Return_Planet_By_ExistingId()
        {
            // Arrange
            var planetId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var planet = new Planet
            {
                Id = planetId,
                Name = "Deimos",
                Diameter = 5,
                Temperature = 80,
                Place = "127.0.12",
                UserId = userId
            };

            _mockPlanetProvider.Setup(x => x.GetById(planetId, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(planet));

            var expectedResult = new Planet
            {
                Id = planetId,
                Name = "Deimos",
                Diameter = 5,
                Temperature = 80,
                Place = "127.0.12",
                UserId = userId
            };

            // Act
            var actualResult = await _planetService.GetById(planetId, CancellationToken.None);

            // Assert
            actualResult
                .Should().NotBeNull()
                .And.BeEquivalentTo(expectedResult);
        }
    }
}
