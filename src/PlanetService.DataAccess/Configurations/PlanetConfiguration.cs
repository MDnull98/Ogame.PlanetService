using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanetService.BusinessLogic.Models;

namespace PlanetService.DataAccess.Configurations
{
    /// <summary>
    ///   Database <strong>"Planets"</strong> table configuration
    /// </summary>
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired();

            builder.Property(c => c.Diameter).IsRequired();

            builder.Property(c => c.Temperature).IsRequired();

            builder.Property(c => c.Place).IsRequired();

            builder.Property(c => c.UserId).IsRequired();

            builder.ToTable("Planets");
        }
    }
}
