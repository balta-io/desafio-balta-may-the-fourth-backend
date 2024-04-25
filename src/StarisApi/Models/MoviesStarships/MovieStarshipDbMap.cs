using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarisApi.Models.MoviesStarships;

namespace StarisApi.Models.MoviesStarship;

public class MovieStarshipDbMap : IEntityTypeConfiguration<MovieStarship>
{
    public void Configure(EntityTypeBuilder<MovieStarship> builder)
    {
        builder.ToTable("MoviesStarships");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MovieId).HasColumnType("int").IsRequired();
        builder.Property(x => x.StarshipId).HasColumnType("int").IsRequired();
    }
}
