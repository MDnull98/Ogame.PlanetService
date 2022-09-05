using PlanetService.BusinessLogic.Providers;

namespace PlanetService.BusinessLogic.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets the now UTC.
        /// </summary>
        /// <value>
        /// The now UTC.
        /// </value>
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
