using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.FilmsPlanet;

public class FilmPlanetDbMap : IEntityTypeConfiguration<FilmPlanet>
{
    public void Configure(EntityTypeBuilder<FilmPlanet> builder)
    {
        builder.ToTable("FilmsPlanets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FilmId).HasColumnType("int").IsRequired();
        builder.Property(x => x.PlanetId).HasColumnType("int").IsRequired();
    }
}
