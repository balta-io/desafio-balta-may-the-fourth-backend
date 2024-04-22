using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.PeopleFilms;

public class PersonFilmDbMap : IEntityTypeConfiguration<PersonFilm>
{
    public void Configure(EntityTypeBuilder<PersonFilm> builder)
    {
        builder.ToTable("PeopleMovies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PersonId).HasColumnType("int").IsRequired();
        builder.Property(x => x.FilmId).HasColumnType("int").IsRequired();
    }
}
