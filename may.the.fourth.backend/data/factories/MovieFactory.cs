using May.The.Fourth.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace May.The.Fourth.Backend.Data.Factories;

public static class MovieFactory
{
    public static void Execute(ModelBuilder modelBuilder)
    {
        var movies = new[]
        {
            new MovieEntity
            {
                Id = 1, Title = "A New Hope", Episode = 4, OpeningCrawl = "", Director = "George Lucas",
                Producer = "Gary Kurtz, Rick McCallum", ReleaseDate = new DateTime(1977, 05, 25)
            },
            new MovieEntity
            {
                Id = 2, Title = "The Empire Strikes Back", Episode = 5, OpeningCrawl = "", Director = "Irvin Kershner",
                Producer = "Gary Kurtz, Rick McCallum", ReleaseDate = new DateTime(1980, 05, 17)
            },
            new MovieEntity
            {
                Id = 3, Title = "Return of the Jedi", Episode = 6, OpeningCrawl = "", Director = "Richard Marquand",
                Producer = "Howard G. Kazanjian, George Lucas, Rick McCallum", ReleaseDate = new DateTime(1983, 05, 25)
            },
            new MovieEntity
            {
                Id = 4, Title = "The Phantom Menace", Episode = 1, OpeningCrawl = "", Director = "George Lucas",
                Producer = "Rick McCallum", ReleaseDate = new DateTime(1999, 05, 19)
            },
            new MovieEntity
            {
                Id = 5, Title = "Attack of the Clones", Episode = 2, OpeningCrawl = "", Director = "George Lucas",
                Producer = "Rick McCallum", ReleaseDate = new DateTime(2002, 05, 16)
            },
            new MovieEntity
            {
                Id = 6, Title = "Revenge of the Sith", Episode = 3, OpeningCrawl = "", Director = "George Lucas",
                Producer = "Rick McCallum", ReleaseDate = new DateTime(2005, 05, 19)
            },
        };
        modelBuilder.Entity<MovieEntity>().HasData(movies);
    }
}