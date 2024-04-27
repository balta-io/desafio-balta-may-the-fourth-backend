using StarisApi.Dtos;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.Planets;

namespace StarisApi.Models.Characters
{
    public class Character : Entity
    {
        public string Name { get; set; } = null!;
        public string BirthYear { get; set; } = null!;
        public string EyeColor { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string HairColor { get; set; } = null!;
        public string Height { get; set; } = null!;
        public string Mass { get; set; } = null!;
        public string SkinColor { get; set; } = null!;

        public int PlanetId { get; set; }
        public virtual Planet Planet { get; set; } = null!;

        public virtual ICollection<CharacterMovie> Movies { get; set; } = null!;

        public override T ConvertToDto<T>()
        {
            var character = new CharacterDto
            {
                Id = Id,
                Name = Name,
                BirthYear = BirthYear,
                EyeColor = EyeColor,
                Gender = Gender,
                HairColor = HairColor,
                Height = Height,
                Mass = Mass,
                SkinColor = SkinColor,
                ImageUrl = ImageUrl,
                Homeworld = new ListDto(PlanetId, Planet.Name),
                Movies = Movies.Select(x => new ListDto(x.MovieId, x.Movie.Title)).ToList()
            } as T;

            return character!;
        }

        //TODO: recorder a partir das infos do JsonElement
        //public Character CharacterFeedRecord(JsonElement info)
        /*{
          var splitIdUrl = info.GetProperty("url").GetString()!.Split("/");
          var splitHomeUrl = info.GetProperty("homeworld").GetString()!.Split("/");
          var splitMoviesUrl = GetUrlRelationsId(info.GetProperty("films"));
          var id = GetIdFromUrl(splitIdUrl);
          var name = StringNamesFixer(info.GetProperty("name").GetString()!);

          return new Character
          {
              Id = id,
              Name = name,
              Height = info.GetProperty("height").GetString()!,
              Mass = info.GetProperty("mass").GetString()!,
              HairColor = info.GetProperty("hair_color").GetString()!,
              SkinColor = info.GetProperty("skin_color").GetString()!,
              EyeColor = info.GetProperty("eye_color").GetString()!,
              BirthYear = info.GetProperty("birth_year").GetString()!,
              Gender = info.GetProperty("gender").GetString()!,
              PlanetId = GetIdFromUrl(splitHomeUrl),
              ImageUrl = $"{_imgUrlBase}{character.Name.Replace(" ", "_")}",
              Movies = new CharacterMovie //em loop
                       {
                         CharacterId = id,
                         MovieId = ids[i],
                       };
          }; 
         }*/

        public override string GetSearchParameter() => "Name";
    }
}