using May.The.Fourth.Backend.Data.Interfaces;
using May.The.Fourth.Backend.Services.Interfaces;
using May.The.Fourth.Backend.Services.Mappers;
using May.The.Fourth.Backend.Services.Messages;

namespace May.The.Fourth.Backend.Services;

public class StarshipService(IStarshipRepository starshipRepository) : IStarshipService
{
    public async Task<StarshipListResponse> GetStarships()
    {
        try
        {
            var starshipListResponse = new StarshipListResponse();
            var starships = await starshipRepository.GetStarships();
            
            if (starships.Any())
            {
                starshipListResponse.Success = true;
                starshipListResponse.Message = "SUCCESS";
                starshipListResponse.StatusCode = 200;
                starshipListResponse.StarshipDto = MapperDto.MapToStarshipDto(starships);
            }
            else
            {
                starshipListResponse.Success = false;
                starshipListResponse.Message = "FAILED";
                starshipListResponse.StatusCode = 500;
                starshipListResponse.StarshipDto = null;
            }
            return starshipListResponse;
        }
        catch(Exception)
        {
            return new StarshipListResponse
            {
                Success = false,
                Message = "Internal server error",
                StatusCode = 500,
                StarshipDto = null
            };
        }
    }
}