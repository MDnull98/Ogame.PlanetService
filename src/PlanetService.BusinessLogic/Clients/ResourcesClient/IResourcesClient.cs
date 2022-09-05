namespace PlanetService.BusinessLogic.Clients.ResourcesClient
{
    /// <summary>Abstraction for resource client.</summary>
    public interface IResourcesClient
    {
        /// <summary>Gets the resources.</summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Collection of Resource value.</returns>
        Task<List<ResourceValue>> GetResources(Guid planetId, CancellationToken token);
        /// <summary>
        /// Withdraws the resources.
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="resources">The resources.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task WithdrawResources(Guid planetId, List<ResourceValue> resources, CancellationToken token);

        /// <summary>
        /// Deposits the resources.
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="resources">The resources.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task DepositResources(Guid planetId, List<ResourceValue> resources, CancellationToken token);
    }
}
