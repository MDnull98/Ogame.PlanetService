using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using BLL = PlanetService.BusinessLogic.Clients;

namespace PlanetService.Grpc.Clients
{
    public class MockCatalogClient : ICatalogClient
    {
        private readonly ILogger<CatalogConstructionLevel> _logger;

        public MockCatalogClient(ILogger<CatalogConstructionLevel> logger)
        {
            _logger = logger;
        }
        public async Task<List<CatalogConstruction>> GetConstructions(CancellationToken token)
        {
            var levels1 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 1,
                ConstructionId = Guid.Parse("b9741be2-4902-4b6e-a79a-69c369744ac6"),
                DelayInSeconds = 10,
                EnergyCost = 10,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                ResourceProduce = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 3
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 2
                    }
                }
            };

            var levels1_1 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 2,
                ConstructionId = Guid.Parse("b9741be2-4902-4b6e-a79a-69c369744ac6"),
                DelayInSeconds = 20,
                EnergyCost = 12,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                ResourceProduce = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 3
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 2
                    }
                }
            };

            var level1 = new List<CatalogConstructionLevel> {
                levels1,
                levels1_1
            };

            var levels2 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 1,
                ConstructionId = Guid.Parse("7449140a-fe1f-475e-a4c6-c8b82ebcb825"),
                DelayInSeconds = 10,
                EnergyCost = 10,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                BoostBuildSpeed = new List<CatalogConstructionBoost>{
                    new()
                    {
                        Type = CatalogConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY,
                        Value = 30
                    }
                }
            };

            var levels2_2 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 2,
                ConstructionId = Guid.Parse("7449140a-fe1f-475e-a4c6-c8b82ebcb825"),
                DelayInSeconds = 20,
                EnergyCost = 20,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                BoostBuildSpeed = new List<CatalogConstructionBoost>{
                    new()
                    {
                        Type = CatalogConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY,
                        Value = 30
                    }
                }
            };

            var level2 = new List<CatalogConstructionLevel> {
                levels2,
                levels2_2
            };

            var levels3 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 1,
                ConstructionId = Guid.Parse("b6ce1afe-51d2-46c5-865a-89696cc7468d"),
                DelayInSeconds = 10,
                EnergyCost = 10,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                BoostShipSpeedPercent = 2.3
            };

            var levels3_3 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 2,
                ConstructionId = Guid.Parse("b6ce1afe-51d2-46c5-865a-89696cc7468d"),
                DelayInSeconds = 20,
                EnergyCost = 20,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                BoostShipSpeedPercent = 2.7
            };

            var level3 = new List<CatalogConstructionLevel> {
                levels3,
                levels3_3
            };

            var construction1 = new CatalogConstruction
            {
                Id = Guid.Parse("b9741be2-4902-4b6e-a79a-69c369744ac6"),
                Name = "Metal mine",
                Image = "Link",
                ShortDescripton = "ShortDesc",
                Description = "Desc",
                Type = CatalogConstructionType.CONSTRUCTION_TYPE_METAL_STORAGE_PRODUCER,
                DependsLevelOn = new List<Guid>(),
                Levels = level1
            };

            var construction2 = new CatalogConstruction
            {
                Id = Guid.Parse("7449140a-fe1f-475e-a4c6-c8b82ebcb825"),
                Name = "Nanite factory",
                Image = "Link",
                ShortDescripton = "ShortDesc2",
                Description = "Desc2",
                Type = CatalogConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER,
                DependsLevelOn = new List<Guid>(),
                Levels = level2
            };

            var construction3 = new CatalogConstruction
            {
                Id = Guid.Parse("b6ce1afe-51d2-46c5-865a-89696cc7468d"),
                Name = "Metal storage",
                Image = "Link",
                ShortDescripton = "ShortDesc3",
                Description = "Desc3",
                Type = CatalogConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER,
                DependsLevelOn = new List<Guid>(),
                Levels = level3
            };

            var constructions = new List<CatalogConstruction> {
                construction1,
                construction2,
                construction3
            };

            await Task.Delay(100, token);

            return constructions;
        }

        public async Task<CatalogConstruction?> GetConstructionByType(CatalogConstructionType type, CancellationToken token)
        {
            await Task.Delay(100, token);

            var levels1 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 1,
                ConstructionId = Guid.Parse("b9741be2-4902-4b6e-a79a-69c369744ac6"),
                DelayInSeconds = 10,
                EnergyCost = 10,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                ResourceProduce = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 3
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 2
                    }
                }
            };

            var levels1_1 = new CatalogConstructionLevel
            {
                Id = Guid.NewGuid(),
                LevelValue = 2,
                ConstructionId = Guid.Parse("b9741be2-4902-4b6e-a79a-69c369744ac6"),
                DelayInSeconds = 20,
                EnergyCost = 12,
                ResourceCost = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                },
                ResourceProduce = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 3
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 2
                    }
                }
            };

            var level1 = new List<CatalogConstructionLevel> {
                levels1,
                levels1_1
            };

            var mockResponse = new CatalogConstruction
            {
                Id = Guid.Parse("b9741be2-4902-4b6e-a79a-69c369744ac6"),
                Name = "Metal mine",
                Image = "Link",
                ShortDescripton = "ShortDesc",
                Description = "Desc",
                Type = CatalogConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY,
                DependsLevelOn = new List<Guid>(),
                Levels = level1
            };

            return mockResponse;
        }

        public async Task<CatalogConstructionLevel> GetConstructionLevelByType(CatalogConstructionType catalogConstructionType, int levelValue, CancellationToken token)
        {
            var allConstruction = await GetConstructions(token);
            var building = allConstruction.FirstOrDefault(x => x.Type == catalogConstructionType);

            if (building == null)
            {
                _logger.LogWarning("Construction is not found for catalogConstructionType={catalogConstructionType}",
                    catalogConstructionType);

                throw new ApplicationException($"Requested catalog construction with Type=({catalogConstructionType}) is not found");
            }

            var buildingLevel = building.Levels.FirstOrDefault(x => x.LevelValue == levelValue);
            if (buildingLevel == null)
            {
                _logger.LogWarning("Requested level {buildingLevelValue} not found for catalog construction with Type=({catalogConstructionType})",
                    levelValue,
                    catalogConstructionType);

                throw new ApplicationException("Requested level is not found");
            }

            if (buildingLevel.ResourceCost == null)
            {
                _logger.LogTrace("ResourceCost for catalog construction with Type=({catalogConstructionType}) is null",
                    catalogConstructionType);

                throw new ApplicationException("ResourceCost for construction is null");
            }

            return buildingLevel;
        }

        public async Task<List<CatalogMilitaryConstructions>> GetMilitaryConstructions(CancellationToken token)
        {
            await Task.Delay(100, token);

            return new List<CatalogMilitaryConstructions>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Battleship",
                    ImageUrl = "",
                    ShortDescription = "Battleship",
                    Description = "Battleship",
                    Armor = 1,
                    Shield = 2,
                    Attack = 3,
                    Speed = 4,
                    DelayInSeconds = 5,
                    LoadCapacity = 6,
                    FuelConsumption = 7,
                    Type = CatalogMilitaryConstructionType.Battleship,
                    ResourceCosts = new List<BLL.ResourceValue> {
                    new()
                    {
                        Type = BLL.ResourceType.Metal,
                        Value = 30
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Deuterium,
                        Value = 20
                    },
                    new()
                    {
                        Type = BLL.ResourceType.Crystal,
                        Value = 10
                    }
                    },
                    DependentLevels = new List<Guid>()
                }
            };
        }
    }
}
