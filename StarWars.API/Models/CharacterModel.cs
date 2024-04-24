namespace StarWars.API.Models;

public class CharacterModel
{
    public CharacterModel()
    {

    }

    public int CharacterId { get; set; }
    public string Name { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }
}
