using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanetService.BusinessLogic.Models;

namespace PlanetService.DataAccess.Configurations
{
    /// <summary>Planet Military Construction Configuration.</summary>
    public class PlanetMilitaryConstructionConfiguration : IEntityTypeConfiguration<PlanetMilitaryConstruction>
    {
        /// <summary>Configures the entity of type <span class="typeparameter">TEntity</span>.</summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<PlanetMilitaryConstruction> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Type).IsRequired();

            builder.Property(e => e.Amount).IsRequired();

            builder.Property(x => x.MilitaryCatalogConstructionId).IsRequired();

            builder.HasOne(x => x.Planet)
                .WithMany(x => x.MilitaryConstructions)
                .HasForeignKey(x => x.PlanetId);

            builder.ToTable("PlanetMilitaryConstructions");
        }
    }
}
