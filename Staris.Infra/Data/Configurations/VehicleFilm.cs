using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class VehicleFilmConfiguration : IEntityTypeConfiguration<VehicleFilm>
    {
        public void Configure(EntityTypeBuilder<VehicleFilm> builder)
        {
            builder.Property(vf => vf.VehicleId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(vf => vf.FilmId)
                .ValueGeneratedOnAdd()
                .IsRequired();


            builder.Property(vf => vf.Vehicle);
            builder.Property(vf => vf.Film);

            builder.HasOne(v => v.Vehicle)
                .WithMany(f => f.Films)
                .HasForeignKey(vf => vf.VehicleId)
                .HasConstraintName("fk_vehicle_film");

            builder.HasOne(f => f.Film)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(vf => vf.FilmId)
                .HasConstraintName("fk_film_vehicle");

            builder.ToTable("VehicleFilm");

        }
    }
}
