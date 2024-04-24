using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
	public class CharacterConfiguration : IEntityTypeConfiguration<Character>
	{
		public void Configure(EntityTypeBuilder<Character> builder)
		{

			builder.Property(p => p.Id)
				.HasColumnName("CharacterId")
				.ValueGeneratedOnAdd()
				.IsRequired();
				
			builder.Property(p => p.Name)
				.HasColumnType("text")
				.IsRequired();

			builder.Property(p => p.BirthYear)
				.HasColumnType("text") //BBY or ABY
				.IsRequired();

			builder.Property(p => p.BirthYearPeriod)
				.HasColumnType("text")
				.IsRequired();

			builder.Property(p => p.Gender)
				.HasColumnType("INTEGER")
				.IsRequired();

			builder.Property(p => p.Mass)
				.HasColumnType("text")
				.IsRequired();

            builder.Property(p => p.Height)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.EyeColor)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.SkinColor)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.HairColor)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.Mass)
                .HasColumnType("text")
                .IsRequired();

			builder.HasKey(p => p.Id);				

            builder.Property(p => p.HomeWorldId);

			builder.ToTable("Characters");

            builder.HasOne(p => p.HomeWorld)
                .WithMany()
                .HasForeignKey(f => f.HomeWorldId)
                .HasConstraintName("fk_Planets_Characters");
        }
	}
}
