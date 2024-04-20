namespace MayTheFourth.Backend.Entitites;

public class Character
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }
    public Planet Planet { get; set; }
    public List<Film>? Films { get; set; }
}
