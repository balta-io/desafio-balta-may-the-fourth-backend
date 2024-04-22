using MayTheFourth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayTheFourth.Infra.Data.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.BirthYear)
            .IsRequired()
            .HasColumnName("BirthYear")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.EyeColor)
            .IsRequired()
            .HasColumnName("EyeColor")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.Gender)
            .IsRequired()
            .HasColumnName("Gender")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.HairColor)
            .IsRequired()
            .HasColumnName("HairColor")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.Height)
            .IsRequired()
            .HasColumnName("Height")
            .HasColumnType("INT");

        builder.Property(x => x.Mass)
            .IsRequired()
            .HasColumnName("Mass")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.SkinColor)
            .IsRequired()
            .HasColumnName("SkinColor")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

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

        #region relationships

        builder.HasOne(x => x.Homeworld)
            .WithMany()
            .HasForeignKey(x => x.HomeworldId)
            .IsRequired();

        builder.HasMany(x => x.Species)
            .WithMany(x => x.People)
            .UsingEntity<Dictionary<string, object>>("PersonSpecies",
            species => species.HasOne<Species>()
                    .WithMany()
                    .HasForeignKey("SpeciesId")
                    .OnDelete(DeleteBehavior.Cascade),
                person => person.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("PersonId")
                    .OnDelete(DeleteBehavior.Cascade));

        builder.HasMany(x => x.Starships)
            .WithMany(x => x.Pilots)
            .UsingEntity<Dictionary<string, object>>("PersonStarship",
            starship => starship.HasOne<Starship>()
                    .WithMany()
                    .HasForeignKey("StarshipId")
                    .OnDelete(DeleteBehavior.Cascade),
                person => person.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("PersonId")
                    .OnDelete(DeleteBehavior.Cascade));

        builder.HasMany(x => x.Vehicles)
            .WithMany(x => x.Pilots)
            .UsingEntity<Dictionary<string, object>>("PersonVehicle",
            vehicle => vehicle.HasOne<Vehicle>()
                    .WithMany()
                    .HasForeignKey("VehicleId")
                    .OnDelete(DeleteBehavior.Cascade),
                person => person.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("PersonId")
                    .OnDelete(DeleteBehavior.Cascade));

        #endregion
    }
}
