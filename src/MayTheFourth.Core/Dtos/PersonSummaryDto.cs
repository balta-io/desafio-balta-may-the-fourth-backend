using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class PersonSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public Guid HomeworldId { get; set; }

}
