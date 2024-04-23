using StarisApi.Dtos;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.Planets;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;

namespace StarisApi.Models.Characters
{
    public sealed class Character : Entity
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
        public Planet Planet { get; set; } = null!;

        public ICollection<CharacterMovie> Movies { get; set; } = null!;

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
                Homeworld = Planet,
                Movies = Movies
            } as T;

            return character!;
        }

        public override string GetSearchParameter() => "Name";
    }
}