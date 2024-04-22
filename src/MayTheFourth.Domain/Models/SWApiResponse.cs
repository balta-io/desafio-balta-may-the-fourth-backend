using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Domain.Models
{
    public class SWApiResponse
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
    }

    public class Films : SWApiResponse
    {
        public List<Film>? Results { get; set; }
    }

    public class People : SWApiResponse
    {
        public List<Person>? Results { get; set; }
    }

    public class Planets : SWApiResponse
    {
        public List<Planet>? Results { get; set; }
    }

    public class Species : SWApiResponse
    {
        public List<Specie>? Results { get; set; }
    }

    public class Vehicles : SWApiResponse
    {
        public List<Vehicle>? Results { get; set; }
    }

    public class Starships : SWApiResponse
    {
        public List<Starship>? Results { get; set; }
    }
}
