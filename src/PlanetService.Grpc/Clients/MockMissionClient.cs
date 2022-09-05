using PlanetService.BusinessLogic.Clients.MissionClient;

namespace PlanetService.Grpc.Clients
{
    /// <summary>Mock mission client service.</summary>
    /// <seealso cref="PlanetService.BusinessLogic.Clients.MissionClient.IMissionClient" />
    public class MockMissionClient : IMissionClient
    {
        /// <summary>Sends the expedition.</summary>
        /// <param name="expeditionRequest">The expedition request.</param>
        /// <param name="token">The token.</param>
        /// <returns>Expedition result.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public async Task<ExpeditionResult> SendExpedition(ExpeditionRequest expeditionRequest, CancellationToken token)
        {
            if (expeditionRequest.user == null)
            {
                throw new ArgumentNullException(nameof(expeditionRequest.user));
            }

            var user = expeditionRequest.user;
            var expeditionResult = new ExpeditionResult
            {
                UserId = user.UserId,
                PlanetId = expeditionRequest.PlanetId,
                SentFromPlanetId = user.SentFromPlanetId,
                ExtractedResources = user.Resources,
                CargoVolume = user.CargoVolume,
                Resources = user.Resources,
                Warships = user.Warships,
                CivilianShips = user.CivilianShips,
                DepartureDateUtc = user.DepartureDateUtc,
                ArrivalDateUtc = user.ArrivalDateUtc,
                ReturnDateUtc = user.ReturnDateUtc
            };

            await Task.Delay(100, token);

            return expeditionResult;
        }
    }
}
