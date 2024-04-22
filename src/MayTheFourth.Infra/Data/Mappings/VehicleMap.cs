using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Infra.Data.Mappings;

public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Model)
            .IsRequired()
            .HasColumnName("Model")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.VehicleClass)
            .IsRequired()
            .HasColumnName("VehicleClass")
            .HasColumnName("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasColumnName("Manufacturer")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Length)
            .IsRequired()
            .HasColumnName("Length")
            .HasColumnType("INT");

        builder.Property(x => x.CostInCredits)
            .IsRequired()
            .HasColumnName("CostInCredits")
            .HasColumnType("DECIMAL");

        builder.Property(x => x.Crew)
            .IsRequired()
            .HasColumnName("Crew")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Passengers)
            .IsRequired()
            .HasColumnName("Passengers")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.MaxAtmospheringSpeed)
            .IsRequired()
            .HasColumnName("MaxAtmospheringSpeed")
            .HasColumnType("INT");

        builder.Property(x => x.CargoCapacity)
            .IsRequired()
            .HasColumnName("CargoCapacity")
            .HasColumnType("INT");

        builder.Property(x => x.Consumables)
            .IsRequired()
            .HasColumnName("Consumables")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Url)
            .IsRequired()
            .HasColumnName("Url")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Created)
            .IsRequired()
            .HasColumnName("Created")
            .HasColumnType("DATETIME");

        builder.Property(x => x.Edited)
            .IsRequired()
            .HasColumnName("Edited")
            .HasColumnType("DATETIME");
    }
}
