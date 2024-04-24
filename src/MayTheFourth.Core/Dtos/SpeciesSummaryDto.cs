using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class SpeciesSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;

    public Guid? HomeworldId { get; set; }
}
