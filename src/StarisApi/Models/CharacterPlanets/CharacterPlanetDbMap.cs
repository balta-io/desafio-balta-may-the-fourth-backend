using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.CharacterPlanets;

public class CharacterPlanetDbMap : IEntityTypeConfiguration<CharacterPlanet>
{
    public void Configure(EntityTypeBuilder<CharacterPlanet> builder)
    {
        builder.ToTable("CharactersPlanetsRelationship");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CharacterId).HasColumnType("int").IsRequired();
        builder.Property(x => x.PlanetId).HasColumnType("int").IsRequired();
    }
}
