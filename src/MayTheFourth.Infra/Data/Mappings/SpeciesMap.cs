using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Infra.Data.Mappings;

public class SpeciesMap : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("Species");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Classification)
            .IsRequired()
            .HasColumnName("Classification")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Designation)
            .IsRequired()
            .HasColumnName("Designation")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.AverageHeight)
            .IsRequired()
            .HasColumnName("AverageHeight")
            .HasColumnType("INT");

        builder.Property(x => x.AverageLifespan)
            .IsRequired()
            .HasColumnName("AverageLifespan")
            .HasColumnType("INT");

        builder.Property(x => x.EyeColors)
            .IsRequired()
            .HasColumnName("EyeColors")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.HairColors)
            .IsRequired()
            .HasColumnName("HairColors")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.SkinColors)
            .IsRequired()
            .HasColumnName("SkinColors")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Language)
            .IsRequired()
            .HasColumnName("Language")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

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

        builder.HasOne(x => x.Homeworld)
            .WithMany()
            .HasForeignKey(x => x.HomeworldId)
            .IsRequired();
    }
}
