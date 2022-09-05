using AutoMapper;
using PlanetService.BusinessLogic.Clients;
using PlanetService.BusinessLogic.Clients.ResourcesClient;
using BLL = PlanetService.BusinessLogic.Clients;

namespace PlanetService.Grpc.Clients
{
    public class MockResourcesClient : IResourcesClient
    {
        private readonly IMapper _mapper;

        public MockResourcesClient(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<BLL.ResourceValue>> GetResources(Guid planetId, CancellationToken token)
        {
            await Task.Delay(1000, token);

            var getResourcesResponse = new List<BLL.ResourceValue>
            {
                new()
                {
                    Type = BLL.ResourceType.Crystal,
                    Value = 3000
                },
                new()
                {
                    Type = BLL.ResourceType.Deuterium,
                    Value = 2000
                },
                new()
                {
                    Type = BLL.ResourceType.Metal,
                    Value = 1000
                }
            };

            var resources = _mapper.Map<List<BLL.ResourceValue>>(getResourcesResponse);

            return resources;
        }

        public async Task WithdrawResources(Guid planetId, List<BLL.ResourceValue> resources, CancellationToken token)
        {
            await Task.Delay(3000, token);
        }

        public async Task DepositResources(Guid planetId, List<BLL.ResourceValue> resources, CancellationToken token)
        {
            await Task.Delay(3000, token);
        }
    }
}
