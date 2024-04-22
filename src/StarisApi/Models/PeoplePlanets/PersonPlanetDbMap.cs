using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.PeoplePlanets;

public class PersonPlanetDbMap : IEntityTypeConfiguration<PersonPlanet>
{
    public void Configure(EntityTypeBuilder<PersonPlanet> builder)
    {
        builder.ToTable("PeoplePlanets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PersonId).HasColumnType("int").IsRequired();
        builder.Property(x => x.PlanetId).HasColumnType("int").IsRequired();
    }
}
