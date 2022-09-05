using AutoMapper;
using PlanetService.BusinessLogic.Clients.BuilderClient;
using PlanetService.BusinessLogic.Clients.CatalogClient;
using PlanetService.BusinessLogic.Clients.MissionClient;
using PlanetService.BusinessLogic.Models;
using PlanetService.Grpc.Mapping.Converters;
using ClientModels = PlanetService.BusinessLogic.Clients;
using MissionClient = PlanetService.BusinessLogic.Clients.MissionClient;
using ServiceModels = PlanetService.BusinessLogic.Models;

namespace PlanetService.Grpc.Mapping
{
    /// <summary>Mapping profile.</summary>
    public class MappingProfile : Profile
    {
        /// <summary>Mapping profile constructor</summary>
        public MappingProfile()
        {
            CreateMap<CatalogConstruction, ServiceModels.Construction>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CatalogConstructionId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CatalogConstructionLevel, Grpc.ConstructionLevel>();

            CreateMap<ClientModels.ResourceValue, Grpc.ResourceValue>()
                .ForMember(d => d.ResourceType, opt => opt.MapFrom(src => src.Type));

            CreateMap<ServiceModels.Construction, Grpc.Construction>()
                .ForMember(d => d.ConstructionId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.CatalogConstructionId, opt => opt.MapFrom(src => src.CatalogConstructionId.ToString()))
                .ForMember(d => d.ConstructionName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(d => d.IsExisten, opt => opt.MapFrom(src => src.IsExisten));

            CreateMap<Construction.Types.ConstructionType, PlanetConstructionType>()
                .ConvertUsing<ConstructionTypeConverter>();

            CreateMap<PlanetModel, Planet>();
            CreateMap<CatalogConstruction, PlanetConstruction>()
                .ForMember(d => d.CatalogConstructionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<ServiceModels.Planet, Grpc.Planet>()
                .ForMember(d => d.PlanetId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.PlanetName, opt => opt.MapFrom(src => src.Name));

            CreateMap<BuilderBuildingQueue, ServiceModels.BuildingQueue>();
            CreateMap<ServiceModels.BuildingQueue, Grpc.BuildingQueue>();
            CreateMap<ServiceModels.PlanetInfo, Grpc.GetPlanetInfoResponse>();
            CreateMap<BuilderBuildingQueueType, BuildingQueueType>();

            CreateMap<Grpc.CreateExpeditionRequest, ExpeditionRequest>();
            CreateMap<Grpc.SpaceshipValue, MissionClient.SpaceshipValue>().ReverseMap();
            CreateMap<Grpc.SpaceshipClassification, MissionClient.SpaceshipClassification>();
        }
    }
}
