using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.MovieStarship;

public class MovieStarshipDbMap : IEntityTypeConfiguration<MovieStarship>
{
    public void Configure(EntityTypeBuilder<MovieStarship> builder)
    {
        builder.ToTable("MovieStarshipsRelationship");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MovieId).HasColumnType("int").IsRequired();
        builder.Property(x => x.StarshipId).HasColumnType("int").IsRequired();
    }
}
