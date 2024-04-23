using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Infra.Data.Configurations
{
	public class CharacterConfiguration : IEntityTypeConfiguration<Character>
	{
		public void Configure(EntityTypeBuilder<Character> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(p => p.Name)
				.IsRequired();

			builder.Property(p => p.BirthYear)
				.HasColumnType("text(8)")
				.IsRequired();

			builder.Property(p => p.BirthYear)
				.HasColumnType("text(3)") //BBY or ABY
				.IsRequired();

			/*
			public decimal BirthYear { get; set; }
			public string BirthYearPeriod { get; set; } = string.Empty;
			public short Gender { get; set; }
			public string Mass { get; set; } = string.Empty;
			public string Height { get; set; } = string.Empty;
			public string EyeColor { get; set; } = string.Empty;
			public string SkinColor { get; set; } = string.Empty;
			public string HairColor { get; set; } = string.Empty;
			public int HomeWorldId { get; set; }
			*/

			builder.Property(p => p.HomeWorldId);

			builder.HasOne(p => p.HomeWorld)
				.WithMany()
				.HasForeignKey(f => f.HomeWorldId)
				.HasConstraintName("fk_Planets_Characters");

			builder.ToTable("Characters");
		}
	}
}
