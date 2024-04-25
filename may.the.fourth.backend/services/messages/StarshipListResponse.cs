using May.The.Fourth.Backend.Services.Dtos;

namespace May.The.Fourth.Backend.Services.Messages;

public class StarshipListResponse : ResponseBase
{
    public IList<StarshipDto>? StarshipDto { get; set; }
}