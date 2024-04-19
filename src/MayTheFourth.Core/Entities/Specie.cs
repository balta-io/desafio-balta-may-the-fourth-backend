namespace MayTheFourth.Core.Entities;

public class Species
{
    public string Name { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string AverageHeight { get; set; } = string.Empty;
    public string AverageLifespan { get; set; } = string.Empty;
    public string EyeColors { get; set; } = string.Empty;
    public string HairColors { get; set; } = string.Empty;
    public string SkinColors { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Homeworld { get; set; } = string.Empty;
    public string[] People { get; set; } = [];
    public string[] Films { get; set; } = [];
    public string Url { get; set; } = string.Empty;
    public string Created { get; set; } = string.Empty;
    public string Edited { get; set; } = string.Empty;
}
