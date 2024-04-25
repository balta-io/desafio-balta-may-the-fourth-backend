using Microsoft.EntityFrameworkCore;

using May.The.Fourth.Backend.Data.Entities;

namespace May.The.Fourth.Backend.Data.Contexts;

public class StarWarsContext(DbContextOptions<StarWarsContext> options) : DbContext(options)
{
    public DbSet<MovieEntity> Filmes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // filmes
        var filmes = new[]
        {
            new MovieEntity { Id = 1, Title = "The Rise of the Jedi", Episode = 10, OpeningCrawl = "After the fall of the Empire, the galaxy face", Director = "Jana Doe", Producer = "Leo Smith", ReleaseDate = new DateTime(2028, 12, 15) },
            new MovieEntity { Id = 2, Title = "The Battle of the Stars" },
            new MovieEntity { Id = 3, Title = "Return of the Light" },
            new MovieEntity { Id = 4, Title = "Warriors of the Shadow Realm" },
            new MovieEntity { Id = 5, Title = "The Galactic Quest" },
            new MovieEntity { Id = 6, Title = "Rise of the Planetara" },
            new MovieEntity { Id = 7, Title = "Echoes of the Stars" },
            new MovieEntity { Id = 8, Title = "The Return of the Voyager" },
            new MovieEntity { Id = 9, Title = "Voyager's Endgame" },
            new MovieEntity { Id = 10, Title = "Galactic Odyssey" },
            new MovieEntity { Id = 11, Title = "The Edge of the Universe" },
        };
        modelBuilder.Entity<MovieEntity>().HasData(filmes);
    }
}