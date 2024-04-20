namespace MayTheFourth.Core.Contexts.SharedContext.UseCases;

public class Response
{
    public string? Message { get; set; } = string.Empty;
    public int Status { get; set; }
    public bool IsSuccess => Status is >= 200 and <= 299;
}
