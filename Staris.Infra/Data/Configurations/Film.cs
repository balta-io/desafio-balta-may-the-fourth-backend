using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder) 
        {
            builder.Property(f => f.Id)
                .HasColumnName("FilmId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(f => f.Episode)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(f => f.OpeningCrawl)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(f => f.Director)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(f => f.Producer)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(f => f.ReleaseDate)
                .HasColumnType("real")
                .IsRequired();

            builder.HasKey(f => f.Id);

            builder.ToTable("Films");
                



        }

    }
}
