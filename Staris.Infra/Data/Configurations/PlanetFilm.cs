using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class PlanetFilmConfiguration : IEntityTypeConfiguration<PlanetFilm>
    {
        public void Configure(EntityTypeBuilder<PlanetFilm> builder)
        {
            builder.Property(pf => pf.FilmId)
                .IsRequired();


            builder.Property(pf => pf.PlanetId)
                .IsRequired();

            builder.Property(pf => pf.Film);

            builder.Property(pf => pf.Planet);


            builder.HasOne(f => f.Film)
                .WithMany(p => p.Planets)
                .HasForeignKey(pf => pf.FilmId)
                .HasConstraintName("fk_film_planet");

            builder.HasOne(p => p.Planet)
                .WithMany(f => f.Movies)
                .HasForeignKey(pf => pf.PlanetId)
                .HasConstraintName("fk_planet_film");

            builder.ToTable("PlanetFilm");
        }
    }
}
