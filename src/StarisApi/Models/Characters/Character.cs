namespace StarisApi.Models.Characters;

public class Character
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
    //public Planet? HomeWorld { get; set; }
    //public ICollection<CharacterMovie> Movies { get; set; } = [];
}
