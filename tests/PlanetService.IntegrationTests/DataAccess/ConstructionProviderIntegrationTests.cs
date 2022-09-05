using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PlanetService.BusinessLogic;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;

namespace PlanetService.IntegrationTests.DataAccess
{
    public class ConstructionProviderIntegrationTests : IClassFixture<GrpcAppFactory>, IDisposable
    {
        private static readonly CancellationToken s_token = CancellationToken.None;

        private readonly IServiceScope _scope;

        private IDataContext _dataContext;
        private IPlanetConstructionRepository _planetConstructionRepository;
        private IConstructionProvider _constructionProvider;
        private IPlanetRepository _planetRepository;
        private readonly Random _random;

        public ConstructionProviderIntegrationTests(GrpcAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _planetConstructionRepository = _scope.ServiceProvider.GetRequiredService<IPlanetConstructionRepository>();
            _constructionProvider = _scope.ServiceProvider.GetRequiredService<IConstructionProvider>();
            _planetRepository = _scope.ServiceProvider.GetRequiredService<IPlanetRepository>();
            _dataContext = _scope.ServiceProvider.GetRequiredService<IDataContext>();
            _random = new Random();
        }

        [Fact]
        public async Task GetBuiltConstructions_Should_Return_BuiltConstructions()
        {
            //Arrange
            var place = _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString();
            var planet = new Planet()
            {
                Name = "Deimos",
                Diameter = 100,
                Temperature = 80,
                Place = place,
                UserId = Guid.NewGuid()
            };

            var planetModel = await _planetRepository.Create(planet, s_token);

            var constructions = new List<PlanetConstruction>()
            {
                new()
                {
                    CatalogConstructionId = Guid.NewGuid(),
                    Type = PlanetConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY,
                    Level = 1,
                    PlanetId = planetModel.Id,
                    Coefficient = 100
                },
                new()
                {
                    CatalogConstructionId = Guid.NewGuid(),
                    Type = PlanetConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER,
                    Level = 1,
                    PlanetId = planetModel.Id,
                    Coefficient = 100
                }
            };

            await _planetConstructionRepository.CreateRange(constructions, s_token);
            await _dataContext.SaveChanges(s_token);

            //Act
            var actualResult = await _constructionProvider.GetBuiltConstructions(planetModel.Id, s_token);

            //Assert
            actualResult
                .Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(2)
                .And.BeEquivalentTo(constructions, config =>
                {
                    return config.Excluding(x => x.Planet);
                });
        }

        [Fact]
        public async Task GetBuiltConstructions_Should_Return_Empty_When_Planet_Id_Not_Found()
        {
            //Arrange
            var planetId = Guid.NewGuid();

            //Act
            var actualResult = await _constructionProvider.GetBuiltConstructions(planetId, s_token);

            //Assert
            actualResult
                .Should()
                .BeEmpty();
        }

        [Fact]
        public async Task GetBuiltConstructionById_Should_Return_BuiltConstruction()
        {
            //Arrange
            var place = _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString();
            var planet = new Planet()
            {
                Name = "Gannimed",
                Diameter = 100,
                Temperature = 80,
                Place = place,
                UserId = Guid.NewGuid()
            };

            var planetModel = await _planetRepository.Create(planet, s_token);

            var construction = new PlanetConstruction()
            {
                CatalogConstructionId = Guid.NewGuid(),
                Type = PlanetConstructionType.CONSTRUCTION_TYPE_METAL_STORAGE_PRODUCER,
                Level = 1,
                PlanetId = planetModel.Id,
                Coefficient = 100
            };

            await _planetConstructionRepository.Create(construction, s_token);
            await _dataContext.SaveChanges(s_token);

            //Act
            var actualResult = await _constructionProvider.GetBuiltConstructionById(construction.Id, s_token);

            //Assert
            actualResult
                .Should()
                .NotBeNull()
                .And.BeEquivalentTo(construction, config =>
                {
                    return config.Excluding(x => x.Planet);
                });
        }

        [Fact]
        public async Task GetBuiltConstructionById_Should_Return_Null_When_Construction_Not_Found()
        {
            //Arrange
            var constructionId = Guid.NewGuid();

            //Act
            var actualResult = await _constructionProvider.GetBuiltConstructionById(constructionId, s_token);

            //Assert
            actualResult
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetBuiltConstructionByPlanetId_Should_Return_BuiltConstruction()
        {
            //Arrange
            var place = _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString();
            var constructionType = PlanetConstructionType.CONSTRUCTION_TYPE_TERRAFORMER_FACTORY;
            var planet = new Planet()
            {
                Name = "Mars",
                Diameter = 100,
                Temperature = 80,
                Place = place,
                UserId = Guid.NewGuid()
            };

            var planetModel = await _planetRepository.Create(planet, s_token);

            var construction = new PlanetConstruction()
            {
                CatalogConstructionId = Guid.NewGuid(),
                Type = constructionType,
                Level = 1,
                PlanetId = planetModel.Id,
                Coefficient = 100
            };

            await _planetConstructionRepository.Create(construction, s_token);
            await _dataContext.SaveChanges(s_token);

            //Act
            var actualResult = await _constructionProvider.GetBuiltConstructionByPlanetId(constructionType, planetModel.Id, s_token);

            //Assert
            actualResult
                .Should()
                .NotBeNull()
                .And.BeEquivalentTo(construction, config =>
                {
                    return config.Excluding(x => x.Planet);
                });
        }

        [Fact]
        public async Task GetBuiltConstructionByPlanetId_Should_ThrowArgumentException_When_Construction_Type_Is_Invalid()
        {
            //Arrange
            var place = _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString() + "."
                + _random.Next(0, 999).ToString();
            var constructionType = PlanetConstructionType.CONSTRUCTION_TYPE_UNSPECIFIED;
            var planet = new Planet()
            {
                Name = "Mars",
                Diameter = 100,
                Temperature = 80,
                Place = place,
                UserId = Guid.NewGuid()
            };

            var planetModel = await _planetRepository.Create(planet, s_token);
            await _dataContext.SaveChanges(s_token);

            //Act
            var actualResult = async () => await _constructionProvider.GetBuiltConstructionByPlanetId(constructionType, planetModel.Id, s_token);

            //Assert
            await actualResult
                .Should()
                .ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task GetBuiltConstructionByPlanetId_Should_Return_Null_When_Planet_Id_Is_Not_Found()
        {
            //Arrange
            var constructionType = PlanetConstructionType.CONSTRUCTION_TYPE_TERRAFORMER_FACTORY;
            var planetId = Guid.NewGuid();

            //Act
            var actualResult = await _constructionProvider.GetBuiltConstructionByPlanetId(constructionType, planetId, s_token);

            //Assert
            actualResult
                .Should()
                .BeNull();
        }

        public void Dispose()
        {
            _dataContext = null;
            _planetConstructionRepository = null;
            _constructionProvider = null;
            _planetRepository = null;

            _scope.Dispose();
        }
    }
}
