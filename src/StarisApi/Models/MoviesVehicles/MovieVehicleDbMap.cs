using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.MoviesVehicles;

public class MovieVehicleDbMap : IEntityTypeConfiguration<MovieVehicle>
{
    public void Configure(EntityTypeBuilder<MovieVehicle> builder)
    {
        builder.ToTable("MoviesVehicles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MovieId).HasColumnType("int").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnType("int").IsRequired();
    }
}
