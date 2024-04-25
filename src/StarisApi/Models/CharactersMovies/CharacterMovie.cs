using StarisApi.Models.Characters;
using StarisApi.Models.Movies;

namespace StarisApi.Models.CharactersMovies;

public class CharacterMovie
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int MovieId { get; set; }
    public virtual Character Character { get; set; } = null!;
    public virtual Movie Movie { get; set; } = null!;
}
