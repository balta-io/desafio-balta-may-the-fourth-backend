using MayTheFourth.Core.Entities;
using System.IO;

namespace MayTheFourth.Core.Dtos;

public class SpeciesSummaryDto
{
    public SpeciesSummaryDto() { }

    public SpeciesSummaryDto(Species species)
    {
        Id = species.Id;
        Name = species.Name;
        Slug = species.Slug;
        Classification = species.Classification;
        Designation = species.Designation;
        Language = species.Language;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
}
