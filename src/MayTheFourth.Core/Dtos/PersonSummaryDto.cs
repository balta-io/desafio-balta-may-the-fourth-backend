using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class PersonSummaryDto
{
    public PersonSummaryDto() { }
    public PersonSummaryDto(Person person)
    {
        Id = person.Id;
        Name = person.Name;
        BirthYear = person.BirthYear;
        Gender = person.Gender;
        HomeworldId = person.HomeworldId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public Guid HomeworldId { get; set; }
}
