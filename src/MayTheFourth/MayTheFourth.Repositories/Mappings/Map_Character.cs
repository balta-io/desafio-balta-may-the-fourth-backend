using MayTheFourth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Repositories.Mappings
{
    internal class Map_Character : BaseMappings<Character>
    {
        public override void Configure(EntityTypeBuilder<Character> builder)
        {
            base.Configure(builder);
            builder.ToTable("Characters");

            builder.Property(c => c.Name);
            builder.Property(c => c.Height);
            builder.Property(c => c.Weight);
            builder.Property(c => c.HairColor);
            builder.Property(c => c.SkinColor);
            builder.Property(c => c.EyeColor);
            builder.Property(c => c.BirthYear);
            builder.Property(c => c.Gender);

            builder.HasOne(c => c.Planet)
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.PlanetId);

            builder.HasMany(c => c.Movies)
                .WithMany(c => c.Characters);
        }
    }
}
