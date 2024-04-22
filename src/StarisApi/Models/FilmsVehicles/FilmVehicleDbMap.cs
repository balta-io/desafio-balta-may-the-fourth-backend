using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.FilmsVehicle;

public class FilmVehicleDbMap : IEntityTypeConfiguration<FilmVehicle>
{
    public void Configure(EntityTypeBuilder<FilmVehicle> builder)
    {
        builder.ToTable("FilmVehicles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FilmId).HasColumnType("int").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnType("int").IsRequired();
    }
}
