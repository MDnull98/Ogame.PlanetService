using AutoMapper;
using PlanetService.BusinessLogic.Models;

namespace PlanetService.Grpc.Mapping.Converters
{
    /// <summary>Converter for construction type.</summary>
    public class ConstructionTypeConverter : ITypeConverter<Construction.Types.ConstructionType, PlanetConstructionType>
    {
        /// <summary>Convert to right type method.</summary>
        /// <param name="source">Grpc construction type model.</param>
        /// <param name="destination">Business construction type model.</param>
        /// <param name="context">Resolution context.</param>
        /// <returns>Planet construction type.</returns>
        /// <exception cref="ApplicationException"></exception>
        public PlanetConstructionType Convert(Construction.Types.ConstructionType source, PlanetConstructionType destination, ResolutionContext context)
        {
            return source switch
            {
                Construction.Types.ConstructionType.AllianceWarehouseFactory => PlanetConstructionType.CONSTRUCTION_TYPE_ALLIANCE_WAREHOUSE_FACTORY,
                Construction.Types.ConstructionType.AstrophysicsTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_ASTROPHYSICS_TECHNOLOGY,
                Construction.Types.ConstructionType.ComputerTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_COMPUTER_TECHNOLOGY,
                Construction.Types.ConstructionType.CrystalProducer => PlanetConstructionType.CONSTRUCTION_TYPE_CRYSTAL_PRODUCER,
                Construction.Types.ConstructionType.CrystalStorageProducer => PlanetConstructionType.CONSTRUCTION_TYPE_CRYSTAL_STORAGE_PRODUCER,
                Construction.Types.ConstructionType.DeuteriumProducer => PlanetConstructionType.CONSTRUCTION_TYPE_DEUTERIUM_PRODUCER,
                Construction.Types.ConstructionType.DeuteriumStorageProducer => PlanetConstructionType.CONSTRUCTION_TYPE_DEUTERIUM_STORAGE_PRODUCER,
                Construction.Types.ConstructionType.EnergyTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_ENERGY_TECHNOLOGY,
                Construction.Types.ConstructionType.EspionageTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_ESPIONAGE_TECHNOLOGY,
                Construction.Types.ConstructionType.GravityTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_GRAVITY_TECHNOLOGY,
                Construction.Types.ConstructionType.HyperspaceEngineTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_HYPERSPACE_ENGINE_TECHNOLOGY,
                Construction.Types.ConstructionType.HyperspaceTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_HYPERSPACE_TECHNOLOGY,
                Construction.Types.ConstructionType.ImpulseMotorTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_IMPULSE_MOTOR_TECHNOLOGY,
                Construction.Types.ConstructionType.IntergalacticResearchNetworkTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_INTERGALACTIC_RESEARCH_NETWORK_TECHNOLOGY,
                Construction.Types.ConstructionType.IonTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_ION_TECHNOLOGY,
                Construction.Types.ConstructionType.JetEngineTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_JET_ENGINE_TECHNOLOGY,
                Construction.Types.ConstructionType.LaserTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_LASER_TECHNOLOGY,
                Construction.Types.ConstructionType.MetalProducer => PlanetConstructionType.CONSTRUCTION_TYPE_METAL_PRODUCER,
                Construction.Types.ConstructionType.MetalStorageProducer => PlanetConstructionType.CONSTRUCTION_TYPE_METAL_STORAGE_PRODUCER,
                Construction.Types.ConstructionType.NaniteFactory => PlanetConstructionType.CONSTRUCTION_TYPE_NANITE_FACTORY,
                Construction.Types.ConstructionType.PlasmaTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_PLASMA_TECHNOLOGY,
                Construction.Types.ConstructionType.ResearchLabFactory => PlanetConstructionType.CONSTRUCTION_TYPE_RESEARCH_LAB_FACTORY,
                Construction.Types.ConstructionType.RobotFactory => PlanetConstructionType.CONSTRUCTION_TYPE_ROBOT_FACTORY,
                Construction.Types.ConstructionType.ShieldTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_SHIELD_TECHNOLOGY,
                Construction.Types.ConstructionType.ShipyardFactory => PlanetConstructionType.CONSTRUCTION_TYPE_SHIPYARD_FACTORY,
                Construction.Types.ConstructionType.SolarPowerPlantProducer => PlanetConstructionType.CONSTRUCTION_TYPE_SOLAR_POWER_PLANT_PRODUCER,
                Construction.Types.ConstructionType.SpaceDockFactory => PlanetConstructionType.CONSTRUCTION_TYPE_SPACE_DOCK_FACTORY,
                Construction.Types.ConstructionType.SpaceshipArmorTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_SPACESHIP_ARMOR_TECHNOLOGY,
                Construction.Types.ConstructionType.TerraformerFactory => PlanetConstructionType.CONSTRUCTION_TYPE_TERRAFORMER_FACTORY,
                Construction.Types.ConstructionType.ThermonuclearPowerPlantProducer => PlanetConstructionType.CONSTRUCTION_TYPE_THERMONUCLEAR_POWER_PLANT_PRODUCER,
                Construction.Types.ConstructionType.WeaponTechnology => PlanetConstructionType.CONSTRUCTION_TYPE_WEAPON_TECHNOLOGY,
                _ => throw new ApplicationException($"Unsupported enum type: {source}"),
            };
        }
    }
}
