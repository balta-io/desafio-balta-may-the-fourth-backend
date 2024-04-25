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
        
        private static StarshipDto MapToStarshipDto(StarshipEntity? starship)
        {
            if (starship == null)
                return new StarshipDto();
            
            return new StarshipDto
            {
                Id = starship.Id,
                Name = starship.Name,
                Model = starship.Model,
                Manufacturer = starship.Manufacturer,
                CostInCredits = starship.CostInCredits,
                Length = starship.Length,
                MaxSpeed = starship.MaxSpeed,
                Crew = starship.Crew,
                Passengers = starship.Passengers,
                CargoCapacity = starship.CargoCapacity,
                HyperdriveRating = starship.HyperdriveRating,
                Mglt = starship.Mglt,
                Consumables = starship.Consumables,
                Class = starship.Class,
            };
        }

        public static IList<StarshipDto> MapToStarshipDto(IList<StarshipEntity> starshipEntities)
        {
            var starships = new List<StarshipDto>();
            
            if (!starshipEntities.Any()) return starships;
            
            starships.AddRange(starshipEntities.Select(MapToStarshipDto));
            
            return starships;
        }
    }
