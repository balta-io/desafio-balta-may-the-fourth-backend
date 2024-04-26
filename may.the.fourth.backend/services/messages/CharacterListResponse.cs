using May.The.Fourth.Backend.Services.Mappers;

namespace May.The.Fourth.Backend.Services.Messages;

public class CharacterListResponse: ResponseBase
{
    public IList<CharacterDto>? CharacterDto { get; set; }
}
