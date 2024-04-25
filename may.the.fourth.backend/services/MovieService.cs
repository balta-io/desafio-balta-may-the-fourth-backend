using May.The.Fourth.Backend.Data.Interfaces;
using May.The.Fourth.Backend.Services.Interfaces;
using May.The.Fourth.Backend.Services.Mappers;
using May.The.Fourth.Backend.Services.Messages;

namespace May.The.Fourth.Backend.Services;

public class MovieService(IMovieRepository movieRepository) : IMovieService
{
    public async Task<MovieListResponse> GetMovies()
    {
        try
        {
            var movieListResponse = new MovieListResponse();
            var movies = await movieRepository.GetMovies();
            
            if (movies.Any())
            {
                movieListResponse.Success = true;
                movieListResponse.Message = "SUCCESS";
                movieListResponse.StatusCode = 200;
                movieListResponse.MovieDto = MapperDto.MapToMovieDto(movies);
            }
            else
            {
                movieListResponse.Success = false;
                movieListResponse.Message = "FAILED";
                movieListResponse.StatusCode = 500;
                movieListResponse.MovieDto = null;
            }
            return movieListResponse;
        }
        catch(Exception)
        {
            return new MovieListResponse
            {
                Success = false,
                Message = "Internal server error",
                StatusCode = 500,
                MovieDto = null
            };
        }
    }
}