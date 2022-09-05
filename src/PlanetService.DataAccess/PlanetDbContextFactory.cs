using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PlanetService.DataAccess
{
    /// <summary>Planet Context factory </summary>
    public class PlanetContextFactory : IDesignTimeDbContextFactory<PlanetContext>
    {
        /// <summary>Create planet db context</summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public PlanetContext CreateDbContext(string[] args)
        {
            var connection = "Host=localhost;Port=5432;Database=PlanetDb;User Id=postgres;Password=123";
            var optionsBuilder = new DbContextOptionsBuilder<PlanetContext>();

            optionsBuilder.UseNpgsql(connection);

            return new PlanetContext(optionsBuilder.Options);
        }
    }
}
