using StarisApi.Models.CharactersMovies;
using StarisApi.Models.Planets;

namespace StarisApi.Dtos
{
    public sealed class CharacterDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BirthYear { get; set; } = null!;
        public string EyeColor { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string HairColor { get; set; } = null!;
        public string Height { get; set; } = null!;
        public string Mass { get; set; } = null!;
        public string SkinColor { get; set; } = null!;
        public Planet Homeworld {  get; set; } = null!;
        public ICollection<CharacterMovie> Movies { get; set; } = null!;
        public string Url { get; set; } = null!;

    }
}
