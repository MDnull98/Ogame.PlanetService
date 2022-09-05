namespace PlanetService.BusinessLogic
{
    /// <summary>
    ///   Data Context abstraction
    /// </summary>
    public interface IDataContext
    {
        /// <summary>Saves the context changes.</summary>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>
        ///   A task that represents the asynchronous save operation.
        /// </returns>
        Task SaveChanges(CancellationToken token);
    }
}
