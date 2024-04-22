using StarisApi.Models.Characters;
using System.Text.Json.Serialization;

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

        public string Url { get; set; } = null!;

    }
}
