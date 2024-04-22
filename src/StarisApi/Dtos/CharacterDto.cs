using StarisApi.Models.Characters;
using System.Text.Json.Serialization;

namespace StarisApi.Dtos
{
    public sealed class CharacterDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
