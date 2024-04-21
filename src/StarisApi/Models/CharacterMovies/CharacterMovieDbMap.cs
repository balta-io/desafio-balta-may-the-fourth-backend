using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.CharacterMovies;

public class CharacterMovieDbMap : IEntityTypeConfiguration<CharacterMovie>
{
    public void Configure(EntityTypeBuilder<CharacterMovie> builder)
    {
        builder.ToTable("CharactersMoviesRelationship");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CharacterId).HasColumnType("int").IsRequired();
        builder.Property(x => x.MovieId).HasColumnType("int").IsRequired();
    }
}
