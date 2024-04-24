using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Infra.Data.Mappings;

public class PlanetMap : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.ToTable("Planets");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.Diameter)
            .IsRequired()
            .HasColumnName("Diameter")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.RotationPeriod)
            .IsRequired()
            .HasColumnName("RotationPeriod")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.OrbitalPeriod)
            .IsRequired()
            .HasColumnName("OrbitalPeriod")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.Gravity)
            .IsRequired()
            .HasColumnName("Gravity")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Population)
            .IsRequired()
            .HasColumnName("Population")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Climate)
            .IsRequired()
            .HasColumnName("Climate")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.Terrain)
            .IsRequired()
            .HasColumnName("Terrain")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.SurfaceWater)
            .IsRequired()
            .HasColumnName("SurfaceWater")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

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
    }
}
