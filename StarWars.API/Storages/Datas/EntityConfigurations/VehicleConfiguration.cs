using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).ValueGeneratedOnAdd();

        builder.Property(v => v.Name)
            .HasMaxLength(100);
        builder.Property(v => v.Model)
            .HasMaxLength(100);
        builder.Property(v => v.Class)
            .HasMaxLength(100)
            .HasColumnName("vehicle_class");
        builder.Property(v => v.Manufacturer)
            .HasMaxLength(100);
        builder.Property(v => v.CostInCredits)
            .HasMaxLength(100)
            .HasColumnName("cost_in_credits");
        builder.Property(v => v.Length)
            .HasMaxLength(100);
        builder.Property(v => v.Crew)
            .HasMaxLength(100);
        builder.Property(v => v.Passengers)
            .HasMaxLength(100);
        builder.Property(v => v.MaxSpeed)
            .HasMaxLength(100)
            .HasColumnName("max_atmosphering_speed");;
        builder.Property(v => v.CargoCapacity)
            .HasMaxLength(100)
            .HasColumnName("cargo_capacity");
        builder.Property(v => v.Consumables)
            .HasMaxLength(100);
        
    }
}