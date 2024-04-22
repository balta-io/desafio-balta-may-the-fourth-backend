using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.People;

public class PersonDbMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.BirthYear).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.EyeColor).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Gender).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.HairColor).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Height).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Mass).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.SkinColor).HasColumnType("varchar(30)").IsRequired();
    }
}
