using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic;

namespace PlanetService.DataAccess
{
    /// <summary>
    ///   Planet Data Context abstraction
    /// </summary>
    public class PlanetDataContext : IDataContext
    {
        private readonly PlanetContext _context;

        /// <summary>Initializes a new instance of the <see cref="PlanetDataContext" /> class.</summary>
        /// <param name="context">The EntityFramework database context <see cref="DbContext"/> class.</param>
        public PlanetDataContext(PlanetContext context)
        {
            _context = context;
        }

        /// <summary>Saves the context changes.</summary>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task SaveChanges(CancellationToken token)
        {
            return _context.SaveChangesAsync(token);
        }
    }
}
