using MayTheFourth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Repositories.Mappings
{
    internal class Map_Planet : BaseMappings<Planet>
    {
        public override void Configure(EntityTypeBuilder<Planet> builder)
        {
            base.Configure(builder);
            builder.ToTable("Planets");

            builder.Property(c => c.Name);
            builder.Property(c => c.RotationPeriod);
            builder.Property(c => c.OrbitalPeriod);
            builder.Property(c => c.Diameter);
            builder.Property(c => c.Climate);
            builder.Property(c => c.Gravity);
            builder.Property(c => c.Terrain);
            builder.Property(c => c.SurfaceWater);
            builder.Property(c => c.Population);

            builder.HasMany(c => c.Characters)
                .WithOne(c => c.Planet)
                .HasForeignKey(c => c.PlanetId);

            builder.HasMany(c => c.Movies)
                .WithMany(c => c.Planets);
        }
    }
}
