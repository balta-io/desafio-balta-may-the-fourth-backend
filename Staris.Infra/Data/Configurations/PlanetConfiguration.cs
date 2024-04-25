using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder) 
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.RotationPeriod)
               .HasColumnType("integer")
               .IsRequired();

            builder.Property(p => p.OrbitalPeriod)
               .HasColumnType("integer")
               .IsRequired();

            builder.Property(p => p.Diameter)
               .HasColumnType("integer")
               .IsRequired();

            builder.Property(p => p.Climate)
               .HasColumnType("text")
               .IsRequired();

            builder.Property(p => p.Gravity)
               .HasColumnType("integer")
               .IsRequired();

            builder.Property(p => p.SurfaceWater)
               .HasColumnType("integer")
               .IsRequired();

            builder.Property(p => p.Population)
               .HasColumnType("integer")
               .IsRequired();

            builder.HasKey(p => p.Id);

            builder.ToTable("Planets");
                

        }
    }
}
