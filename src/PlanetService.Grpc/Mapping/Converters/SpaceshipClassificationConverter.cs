using AutoMapper;
using MissionClient = PlanetService.BusinessLogic.Clients.MissionClient;

namespace PlanetService.Grpc.Mapping.Converters
{
    /// <summary>Converter for Spaceship type.</summary>
    public class SpaceshipClassificationConverter : ITypeConverter<Grpc.SpaceshipClassification, MissionClient.SpaceshipClassification>
    {
        /// <summary>Convert to right type method.</summary>
        /// <param name="source">Grpc Spaceship type model.</param>
        /// <param name="destination">Business Spaceship type model.</param>
        /// <param name="context">Resolution context.</param>
        /// <returns>Spaceship type.</returns>
        /// <exception cref="ApplicationException"></exception>
        public MissionClient.SpaceshipClassification Convert(Grpc.SpaceshipClassification source, MissionClient.SpaceshipClassification destination, ResolutionContext context)
        {
            return source switch
            {
                SpaceshipClassification.EspionageProbe => MissionClient.SpaceshipClassification.EspionageProbe,
                SpaceshipClassification.SmallCargo => MissionClient.SpaceshipClassification.SmallCargo,
                SpaceshipClassification.Bomber => MissionClient.SpaceshipClassification.Bomber,
                SpaceshipClassification.Cruiser => MissionClient.SpaceshipClassification.Cruiser,
                SpaceshipClassification.Battlecruiser => MissionClient.SpaceshipClassification.BattleCruiser,
                SpaceshipClassification.Battleship => MissionClient.SpaceshipClassification.Battleship,
                SpaceshipClassification.ColonyShip => MissionClient.SpaceshipClassification.ColonyShip,
                SpaceshipClassification.Deathstar => MissionClient.SpaceshipClassification.Deathstar,
                SpaceshipClassification.Destroyer => MissionClient.SpaceshipClassification.Destroyer,
                SpaceshipClassification.HeavyFighter => MissionClient.SpaceshipClassification.HeavyFighter,
                SpaceshipClassification.LargeCargo => MissionClient.SpaceshipClassification.LargeCargo,
                SpaceshipClassification.LightFighter => MissionClient.SpaceshipClassification.LightFighter,
                SpaceshipClassification.Recycler => MissionClient.SpaceshipClassification.Recycler,
                SpaceshipClassification.SolarSatellite => MissionClient.SpaceshipClassification.SolarSatellite,
                _ => throw new ApplicationException($"Unsupported enum type: {source}"),
            };
        }
    }
}
