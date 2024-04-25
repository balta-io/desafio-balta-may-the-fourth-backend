using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class PlanetFilmConfiguration : IEntityTypeConfiguration<PlanetFilm>
    {
        public void Configure(EntityTypeBuilder<PlanetFilm> builder)
        {
			builder.Property(pf => pf.PlanetId)
				.IsRequired();

			builder.Property(pf => pf.FilmId)
                .IsRequired();

            builder.HasOne(f => f.Film)
                .WithMany(p => p.Planets)
                .HasForeignKey(pf => pf.FilmId)
                .HasConstraintName("fk_films_planets");

            builder.HasOne(p => p.Planet)
                .WithMany(f => f.Movies)
                .HasForeignKey(pf => pf.PlanetId)
                .HasConstraintName("fk_planets_films");

			builder.HasKey(k => new { k.PlanetId, k.FilmId });

			builder.ToTable("PlanetFilm");
        }
    }
}
