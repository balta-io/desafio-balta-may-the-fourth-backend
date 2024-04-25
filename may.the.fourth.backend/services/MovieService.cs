using May.The.Fourth.Backend.Data.Interfaces;
using May.The.Fourth.Backend.Services.Interfaces;
using May.The.Fourth.Backend.Services.Mappers;
using May.The.Fourth.Backend.Services.Messages;

namespace May.The.Fourth.Backend.Services;

public class MovieService(IMoviepository moviepository) : IMovieService
{
    public async Task<MovieListResponse> GetMovies()
    {
        try
        {
            var movieListResponse = new MovieListResponse();
            var filmes = await moviepository.GetMovies();
            if (filmes.Any())
            {
                movieListResponse.Success = true;
                movieListResponse.Message = "SUCCESS";
                movieListResponse.StatusCode = 200;
                movieListResponse.FilmeDto = MapperDto.MapToMovieDto(filmes);
            }
            else
            {
                movieListResponse.Success = false;
                movieListResponse.Message = "FAILED";
                movieListResponse.StatusCode = 500;
                movieListResponse.FilmeDto = null;
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
                FilmeDto = null
            };
        }
    }
}