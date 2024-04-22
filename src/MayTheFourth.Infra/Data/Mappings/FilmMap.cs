using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Data.Mappings
{
    public class FilmMap : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Film");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.EpisodeId)
                .IsRequired()
                .HasColumnName("EpisodeId")
                .HasColumnType("INT");

            builder.Property(x => x.OpeningCrawl)
                .IsRequired()
                .HasColumnName("OpeningCrawl")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.Property(x => x.Director)
                .IsRequired()
                .HasColumnName("Director")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.Producer)
                .IsRequired()
                .HasColumnName("Producer")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.ReleaseDate)
                .IsRequired()
                .HasColumnName("ReleaseDate")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Url)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Edited)
                .IsRequired()
                .HasColumnName("Edited")
                .HasColumnType("DATETIME");

            #region relationships
            //// Species relationship
            //builder.HasMany(x => x.SpeciesList)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, object>>("FilmSpecies",
            //    j => j.HasOne<Species>().WithMany().HasForeignKey("SpeciesId"),
            //    j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId")
            //    .OnDelete(DeleteBehavior.Cascade));

            //// Starships relationship
            //builder.HasMany(x => x.Starships)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, object>>("FilmStarship",
            //    j => j.HasOne<Starship>().WithMany().HasForeignKey("StarshipId"),
            //    j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId")
            //    .OnDelete(DeleteBehavior.Cascade));

            //// Vehicles relationship
            //builder.HasMany(x => x.Vehicles)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, object>>("FilmVehicle",
            //    j => j.HasOne<Vehicle>().WithMany().HasForeignKey("VehicleId"),
            //    j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId")
            //    .OnDelete(DeleteBehavior.Cascade));

            //// Characters relationship
            //builder.HasMany(x => x.Characters)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, object>>("FilmCharacter",
            //    j => j.HasOne<Person>().WithMany().HasForeignKey("CharacterId"),
            //    j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId")
            //    .OnDelete(DeleteBehavior.Cascade));

            //// Planets relationship
            //builder.HasMany(x => x.Planets)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, object>>("FilmPlanet",
            //    j => j.HasOne<Planet>().WithMany().HasForeignKey("PlanetId"),
            //    j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId")
            //    .OnDelete(DeleteBehavior.Cascade));




            builder.HasMany(x => x.SpeciesList)
                .WithMany(x => x.Films)
                .UsingEntity<Dictionary<string, object>>("FilmSpecies",
                species => species.HasOne<Species>()
                            .WithMany()
                            .HasForeignKey("SpeciesId")
                            .OnDelete(DeleteBehavior.Cascade),
                film => film.HasOne<Film>()
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)

                );

            builder.HasMany(x => x.Starships)
                .WithMany(x => x.Films)
                .UsingEntity<Dictionary<string, object>>("FilmStarship",
                starship => starship.HasOne<Starship>()
                            .WithMany()
                            .HasForeignKey("StarshipId")
                            .OnDelete(DeleteBehavior.Cascade),
                film => film.HasOne<Film>()
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            builder.HasMany(x => x.Vehicles)
                .WithMany(x => x.Films)
                .UsingEntity<Dictionary<string, object>>("FilmVehicle",
                vehicle => vehicle.HasOne<Vehicle>()
                    .WithMany()
                    .HasForeignKey("VehicleId")
                    .OnDelete(DeleteBehavior.Cascade),
                film => film.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
                );

            builder.HasMany(x => x.Characters)
                .WithMany(x => x.Films)
                .UsingEntity<Dictionary<string, object>>("FilmCharacter",
                character => character.HasOne<Person>()
                            .WithMany()
                            .HasForeignKey("FilmCharacter")
                            .OnDelete(DeleteBehavior.Cascade),
                film => film.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
                );

            builder.HasMany(x => x.Planets)
                .WithMany(x => x.Films)
                .UsingEntity<Dictionary<string, object>>("FilmPlanet",
                planet => planet.HasOne<Planet>()
                    .WithMany()
                    .HasForeignKey("FilmPlanet")
                    .OnDelete(DeleteBehavior.Cascade),
                film => film.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
                );
            #endregion
        }
    }
}
