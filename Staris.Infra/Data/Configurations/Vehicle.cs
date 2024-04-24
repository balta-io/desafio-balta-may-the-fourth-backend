using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;

namespace Staris.Infra.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.Id)
                .HasColumnName("VehicleId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(v => v.Model)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(v => v.Manufacturer)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(v => v.Cost)
                .HasColumnType("real")
                .IsRequired();

            builder.Property(v => v.Lenght)
                .HasColumnType("real")
                .IsRequired();

            builder.Property(v => v.MaxSpeed)
                .HasColumnType("real")
                .IsRequired();

            builder.Property(v => v.Crew)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(v => v.Passengers)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(v => v.CargoCapacity)
                .HasColumnType("real")
                .IsRequired();

            builder.Property(v => v.Consumables)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(v => v.Class)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(v => v.Type)
                .HasColumnType("text") //verificar como ficaria o enum..
                .IsRequired();

            builder.HasKey(v => v.Id);

            builder.ToTable("Vehicles");
           
        }
    }
}
