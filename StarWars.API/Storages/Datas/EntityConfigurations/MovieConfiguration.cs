using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieModel>
    {

        public void Configure(EntityTypeBuilder<MovieModel> builder)
        {
            builder.ToTable("movies");
            builder.HasKey(x=> x.MovieId);
            builder.Property(x=> x.MovieId)
                .HasColumnName("Id");

            builder.Property(x => x.Title)
                .HasColumnName("title");

            builder.Property(x => x.EpisodeId)
                .HasColumnName("episode");

            builder.Property(x => x.OpeningCrawl)
                .HasColumnName("openingCrawl");

            builder.Property(x => x.Director)
                .HasColumnName("director");

            builder.Property(x => x.Producer)
                .HasColumnName("producer");

            builder.Property(x => x.ReleaseDate)
                .HasColumnName("releaseDate");

            builder.Ignore(x => x.Url);

            //builder.Ignore(x=> x.Vehicles);
        }
    }
}

