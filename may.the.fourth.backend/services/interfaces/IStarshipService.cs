using May.The.Fourth.Backend.Services.Messages;

namespace May.The.Fourth.Backend.Services.Interfaces;

public interface IStarshipService
{
    Task<StarshipListResponse> GetStarships();
}