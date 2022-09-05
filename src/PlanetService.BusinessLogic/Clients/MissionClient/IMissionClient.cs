namespace PlanetService.BusinessLogic.Clients.MissionClient
{
    /// <summary>Abstraction for mission client.</summary>
    public interface IMissionClient
    {
        /// <summary>Sends the expedition.</summary>
        /// <param name="expeditionRequest">The expedition request.</param>
        /// <param name="token">The token.</param>
        /// <returns>Expedition result.</returns>
        Task<ExpeditionResult> SendExpedition(ExpeditionRequest expeditionRequest, CancellationToken token);
    }
}
