using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.MoviePlanet;

public class MoviePlanetDbMap : IEntityTypeConfiguration<MoviePlanet>
{
    public void Configure(EntityTypeBuilder<MoviePlanet> builder)
    {
        builder.ToTable("MoviesPlanetsRelationship");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MovieId).HasColumnType("int").IsRequired();
        builder.Property(x => x.PlanetId).HasColumnType("int").IsRequired();
    }
}
