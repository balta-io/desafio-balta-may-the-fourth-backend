using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.Films;

public class FilmDbMap : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("Films");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Producer).HasColumnType("varchar(50)").IsRequired();
        builder.Property(x => x.Director).HasColumnType("varchar(50)").IsRequired();
        //Boa ideia fazer essa validação no banco mas preferêncialmente ela deve ser feita tb na entidade
        builder.Property(x => x.Episode).HasColumnType("int").IsRequired().HasAnnotation("CheckConstraint", "CK_Episode_MinValue: Episode >= 1");
        builder.Property(x => x.OpeningCrawl).HasColumnType("varchar(50)").IsRequired();
        builder.Property(x => x.ReleaseDate).HasColumnType("varchar(50)").IsRequired();
        builder.Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();
    }
}
