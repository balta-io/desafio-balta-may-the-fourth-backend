namespace MayTheFourth.Core.Entities;

public class People
{
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public string BirthYear { get; set; } = string.Empty;
        public string EyeColor { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string HairColor { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Mass { get; set; } = string.Empty;
        public string SkinColor { get; set; } = string.Empty;
        public string Homeworld { get; set; } = string.Empty;
        public string[] Films { get; set; } = [];
        public string[] Species { get; set; } = [];
        public string[] Starships { get; set; } = [];
        public string[] Vehicles { get; set; } = [];
        public string Url { get; set; } = string.Empty;
        public string Created { get; set; } = string.Empty;
        public string Edited { get; set; } = string.Empty;
    }

}
