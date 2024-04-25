using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class CharacterFilmConfiguration : IEntityTypeConfiguration<CharacterFilm>
    {
        public void Configure(EntityTypeBuilder<CharacterFilm> builder)
        {
            builder.Property(cf => cf.CharacterId)
                .IsRequired();
            
            builder.Property(cf => cf.FilmId)
                .IsRequired();

			builder.HasOne(c => c.Character)
                .WithMany(f => f.Movies)
                .HasForeignKey(cf => cf.CharacterId)
                .HasConstraintName("fk_characters_films")
                .HasPrincipalKey(pk => pk.Id);

            builder.HasOne(f => f.Film)
                .WithMany(c => c.Characters)
                .HasForeignKey(cf => cf.FilmId)
                .HasConstraintName("fk_films_characters")
				.HasPrincipalKey(pk => pk.Id);

			builder.HasKey(k => new { k.CharacterId, k.FilmId });

			builder.ToTable("CharacterFilms");

        }
    }
}
