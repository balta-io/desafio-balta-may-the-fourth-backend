using MayTheFourth.Core.Dtos;

namespace MayTheFourth.Core.Contexts.SpeciesContext.UseCases.SearchById;

public class Response : SharedContext.UseCases.Response
{
    public Response(string message, int status)
    {
        Message = message; 
        Status = status;
    }

    public Response(string message, ResponseData responseData)
    {
        Message = message;
        Status = 200;
        Data = responseData;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(SpeciesDetailsDto species);
