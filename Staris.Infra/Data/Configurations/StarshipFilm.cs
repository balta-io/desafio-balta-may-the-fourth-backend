using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    internal class StarshipFilmConfiguration : IEntityTypeConfiguration<StarshipFilm>
    {
        public void Configure(EntityTypeBuilder<StarshipFilm> builder)
        {
            builder.Property(sf => sf.VehicleId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(sf => sf.FilmId)
                .ValueGeneratedOnAdd()
                .IsRequired();


            builder.Property(sf => sf.Starship);
            builder.Property(sf => sf.Film);

            builder.HasOne(s => s.Starship)
                .WithMany(f => f.Films)
                .HasForeignKey(sf => sf.VehicleId)
                .HasConstraintName("fk_starship_film");

            builder.HasOne(f => f.Film)
                .WithMany(s => s.Starships)
                .HasForeignKey(sf => sf.FilmId)
                .HasConstraintName("fk_film_starship");

            builder.ToTable("StarshipFilm");
            

        }
    }
}
