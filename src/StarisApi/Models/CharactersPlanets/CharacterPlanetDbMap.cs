using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.CharactersPlanets;

public class CharacterPlanetDbMap : IEntityTypeConfiguration<CharacterPlanet>
{
    public void Configure(EntityTypeBuilder<CharacterPlanet> builder)
    {
        builder.ToTable("CharacetsPlanets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CharacterId).HasColumnType("int").IsRequired();
        builder.Property(x => x.PlanetId).HasColumnType("int").IsRequired();
    }
}
