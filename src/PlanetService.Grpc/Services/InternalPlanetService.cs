using AutoMapper;
using Grpc.Core;

namespace PlanetService.Grpc.Services
{
    public class InternalPlanetService : Grpc.InternalPlanetService.InternalPlanetServiceBase
    {
        private readonly IMapper _mapper;

        public InternalPlanetService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<CompleteBuildingNotifyResponse> CompleteBuildingNotify(CompleteBuildingNotifyRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            await Task.Delay(100, token);

            return new CompleteBuildingNotifyResponse();
        }

        public override async Task<GetRecalculationDataResponse> GetRecalculationData(GetRecalculationDataRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            await Task.Delay(100, token);

            var produced = new List<ResourceValue>
            {
                new()
                {
                    ResourceType = ResourceType.Crystal,
                    Value = 4
                },
                new()
                {
                    ResourceType = ResourceType.Deuterium,
                    Value = 5
                },
                new()
                {
                    ResourceType = ResourceType.Metal,
                    Value = 6
                }
            };

            var consumed = new List<ResourceValue>
            {
                new()
                {
                    ResourceType = ResourceType.Crystal,
                    Value = 1
                },
                new()
                {
                    ResourceType = ResourceType.Deuterium,
                    Value = 2
                },
                new()
                {
                    ResourceType = ResourceType.Metal,
                    Value = 3
                }
            };

            var productors = new ProductorInformation();
            productors.ResourcesConsumeds.Add(consumed);
            productors.ResourcesProduceds.Add(produced);
            productors.Coefficient = 100;
            productors.Count = 1;

            var response = _mapper.Map<GetRecalculationDataResponse>(productors);

            return response;
        }

        public override async Task<GetResourcesGrowthPerHourResponse> GetResourcesGrowthPerHour(GetResourcesGrowthPerHourRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            await Task.Delay(100, token);

            var resources = new List<ResourceValue>
            {
                new()
                {
                    ResourceType = ResourceType.Crystal,
                    Value = 4
                },
                new()
                {
                    ResourceType = ResourceType.Deuterium,
                    Value = 5
                },
                new()
                {
                    ResourceType = ResourceType.Metal,
                    Value = 6
                }
            };

            var response = _mapper.Map<GetResourcesGrowthPerHourResponse>(resources);

            return response;
        }
    }
}
