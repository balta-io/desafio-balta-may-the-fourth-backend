namespace MayTheFouthBackend.Domain.Entities;

public class Planet : Entity
{
    private List<int> _characteres; 
    private List<int> _moveis; 
    public Planet(string name, 
                string rotationPeriod, 
                string orbitalPeriod, 
                string diameter, 
                string climate, 
                string gravity, 
                string terrain, 
                string surfaceWater, 
                string population)
    {
        Name = name;
        RotationPeriod = rotationPeriod;
        OrbitalPeriod = orbitalPeriod;
        Diameter = diameter;
        Climate = climate;
        Gravity = gravity;
        Terrain = terrain;
        SurfaceWater = surfaceWater;
        Population = population;

        _moveis = new List<int>();
        _characteres = new List<int>();
    }

    public string Name { get; private set; }
    public string RotationPeriod { get; private set; }
    public string OrbitalPeriod { get; private set; }
    public string Diameter { get; private set; }
    public string Climate { get; private set; }
    public string Gravity { get; private set; }
    public string Terrain { get; private set; }
    public string SurfaceWater { get; private set; }
    public string Population { get; private set; }

    //TODO IReadOnlyCollection de Personagens
    public IReadOnlyCollection<int> Characters { get => _characteres;  }

    //TODO IReadOnlyCollection de Filmes
    public IReadOnlyCollection<int> Movies { get => _moveis;}

    public void AddCharacter(int character) =>_characteres.Add(character);
    public void AddMoveis(int move) =>_moveis.Add(move);
}
