using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieModel>
    {

        public void Configure(EntityTypeBuilder<MovieModel> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(x=> x.MovieId);
            builder.Property(x=> x.MovieId).ValueGeneratedOnAdd();
        }
    }
}

