using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanetService.BusinessLogic.Models;

namespace PlanetService.DataAccess.Configurations
{
    /// <summary>
    ///   Database <strong>"Planet constructions"</strong> table configuration
    /// </summary>
    public class PlanetConstructionConfiguration : IEntityTypeConfiguration<PlanetConstruction>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<PlanetConstruction> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Type).IsRequired();

            builder.Property(e => e.Level).IsRequired();

            builder.Property(c => c.Coefficient).IsRequired(false);

            builder.Property(x => x.CatalogConstructionId).IsRequired();

            builder.HasOne(x => x.Planet)
                .WithMany(x => x.Constructions)
                .HasForeignKey(x => x.PlanetId);

            builder.ToTable("PlanetConstructions");
        }

    }
}
