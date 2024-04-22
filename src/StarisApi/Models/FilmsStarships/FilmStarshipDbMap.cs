using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarisApi.Models.FilmsStarship;

namespace StarisApi.Models.MovieStarship;

public class FilmStarshipDbMap : IEntityTypeConfiguration<FilmStarship>
{
    public void Configure(EntityTypeBuilder<FilmStarship> builder)
    {
        builder.ToTable("FilmsStarships");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FilmId).HasColumnType("int").IsRequired();
        builder.Property(x => x.StarshipId).HasColumnType("int").IsRequired();
    }
}
