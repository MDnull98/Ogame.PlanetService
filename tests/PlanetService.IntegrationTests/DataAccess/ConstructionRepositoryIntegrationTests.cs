using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PlanetService.BusinessLogic;
using PlanetService.BusinessLogic.Models;
using PlanetService.BusinessLogic.Providers;
using PlanetService.BusinessLogic.Repositories;

namespace PlanetService.IntegrationTests.DataAccess
{
    public class ConstructionRepositoryIntegrationTests : IClassFixture<GrpcAppFactory>, IDisposable
    {
        private static readonly CancellationToken s_token = CancellationToken.None;

        private readonly IServiceScope _scope;

        private IDataContext _dataContext;
        private IPlanetConstructionRepository _planetConstructionRepository;
        private IConstructionProvider _constructionProvider;
        private IPlanetRepository _planetRepository;
        private IPlanetProvider _planetProvider;
        public ConstructionRepositoryIntegrationTests(GrpcAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _planetConstructionRepository = _scope.ServiceProvider.GetRequiredService<IPlanetConstructionRepository>();
            _constructionProvider = _scope.ServiceProvider.GetRequiredService<IConstructionProvider>();
            _planetRepository = _scope.ServiceProvider.GetRequiredService<IPlanetRepository>();
            _planetProvider = _scope.ServiceProvider.GetRequiredService<IPlanetProvider>();
            _dataContext = _scope.ServiceProvider.GetRequiredService<IDataContext>();
        }

        [Fact]
        public async Task Create_Should_Create_Construction()
        {
            //Arrange
            var constructionType = PlanetConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY;
            var planet = new Planet()
            {
                Name = "Deimos",
                Diameter = 100,
                Temperature = 80,
                Place = DataGenerator.GetRandomPlace(),
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

            //Act
            await _planetConstructionRepository.Create(construction, s_token);
            await _dataContext.SaveChanges(s_token);

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
        public async Task CreateRange_Should_Create_Range_Of_Constructions()
        {
            //Arrange
            var constructionType1 = PlanetConstructionType.CONSTRUCTION_TYPE_ROBOT_FACTORY;
            var constructionType2 = PlanetConstructionType.CONSTRUCTION_TYPE_SHIPYARD_FACTORY;
            var planet = new Planet()
            {
                Name = "Fobos",
                Diameter = 100,
                Temperature = 80,
                Place = DataGenerator.GetRandomPlace(),
                UserId = Guid.NewGuid()
            };

            var planetModel = await _planetRepository.Create(planet, s_token);

            var constructions = new List<PlanetConstruction>()
            {
                new()
                {
                    CatalogConstructionId = Guid.NewGuid(),
                    Type = constructionType1,
                    Level = 1,
                    PlanetId = planetModel.Id,
                    Coefficient = 100
                },
                new()
                {
                    CatalogConstructionId = Guid.NewGuid(),
                    Type = constructionType2,
                    Level = 1,
                    PlanetId = planetModel.Id,
                    Coefficient = 100
                }
            };

            //Act
            await _planetConstructionRepository.CreateRange(constructions, s_token);
            await _dataContext.SaveChanges(s_token);

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
        public async Task Remove_Should_Remove_Construction()
        {
            //Arrange
            var constructionType = PlanetConstructionType.CONSTRUCTION_TYPE_SOLAR_POWER_PLANT_PRODUCER;
            var planet = new Planet()
            {
                Name = "Pluton",
                Diameter = 100,
                Temperature = 80,
                Place = DataGenerator.GetRandomPlace(),
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
            await _planetConstructionRepository.Remove(construction.Id, s_token);
            await _dataContext.SaveChanges(s_token);

            var actualResult = await _constructionProvider.GetBuiltConstructionById(construction.Id, s_token);

            //Assert
            actualResult
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task Remove_Should_Return_Null_When_Construction_Not_Found()
        {
            //Arrange
            var constructionId = Guid.NewGuid();

            //Act
            await _planetConstructionRepository.Remove(constructionId, s_token);
            await _dataContext.SaveChanges(s_token);

            var actualResult = await _constructionProvider.GetBuiltConstructionById(constructionId, s_token);

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
            _planetProvider = null;

            _scope.Dispose();
        }
    }
}
