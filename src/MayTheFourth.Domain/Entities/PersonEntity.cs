namespace MayTheFourth.Domain.Entities
{
    public class PersonEntity : Entity
    {
        public string? Name { get; set; }
        public string? Height { get; set; }
        public string? Mass { get; set; }
        public string? Hair_color { get; set; }
        public string? Skin_color { get; set; }
        public string? Eye_color { get; set; }
        public string? Birth_year { get; set; }
        public string? Gender { get; set; }
        public string? Homeworld { get; set; }
        public List<string>? Films { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string? Url { get; set; }
    }
}
