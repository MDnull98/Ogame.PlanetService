namespace PlanetService.BusinessLogic.Providers
{
    /// <summary>
    /// Abstraction which provides current datetime.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets the now UTC.
        /// </summary>
        /// <value>
        /// The now UTC.
        /// </value>
        DateTime NowUtc { get; }
    }
}
