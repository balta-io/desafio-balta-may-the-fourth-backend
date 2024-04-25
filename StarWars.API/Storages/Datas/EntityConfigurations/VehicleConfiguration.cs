using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(v => v.VehicleId);
        builder.Property(v => v.VehicleId).ValueGeneratedOnAdd();

        builder.Property(v => v.Name)
            .HasMaxLength(100);
        builder.Property(v => v.Model)
            .HasMaxLength(100);
        builder.Property(v => v.Manufacturer)
            .HasMaxLength(100);
        builder.Property(v => v.Length)
            .HasMaxLength(100);
        builder.Property(v => v.MaxSpeed)
            .HasMaxLength(100);
        builder.Property(v => v.CargoCapacity)
            .HasMaxLength(100);
        builder.Property(v => v.Consumables)
            .HasMaxLength(100);
        builder.Property(v => v.Class)
            .HasMaxLength(100);
    }
}