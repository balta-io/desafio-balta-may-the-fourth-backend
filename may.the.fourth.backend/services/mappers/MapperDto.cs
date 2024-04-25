using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Services.Dtos;

namespace May.The.Fourth.Backend.Services.Mappers;

public static class MapperDto
    {
        private static MovieDto MapToMovieDto(MovieEntity? movie)
        {
            if (movie == null)
                return new MovieDto();
            
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Episode = movie.Episode,
                OpeningCrawl = movie.OpeningCrawl,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public static IList<MovieDto> MapToMovieDto(IList<MovieEntity> movieEntities)
        {
            var movies = new List<MovieDto>();
            
            if (!movieEntities.Any()) return movies;
            movies.AddRange(movieEntities.Select(MapToMovieDto));
            
            return movies;
        }
    }
