using MayTheFourth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Repositories.Mappings
{
    internal class Map_Starship : BaseMappings<Starship>
    {
        public override void Configure(EntityTypeBuilder<Starship> builder)
        {
            base.Configure(builder);
            builder.ToTable("Starships");

            builder.Property(c => c.Name);
            builder.Property(c => c.Model);
            builder.Property(c => c.Manufacturer);
            builder.Property(c => c.CostInCredits);
            builder.Property(c => c.Length);
            builder.Property(c => c.MaxSpeed);
            builder.Property(c => c.Crew);
            builder.Property(c => c.Passengers);
            builder.Property(c => c.CargoCapacity);
            builder.Property(c => c.HyperdriveRating);
            builder.Property(c => c.MGLT);
            builder.Property(c => c.Consumables);
            builder.Property(c => c.Class);

            builder.HasMany(c => c.Movies)
                .WithMany(c => c.Starships);
        }
    }
}
