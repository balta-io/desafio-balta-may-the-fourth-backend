using MayTheFourth.Core.Dtos;
using System.Net;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.Delete;

public class Response : SharedContext.UseCases.Response
{
    public Response(string message, int status)
    {
        Message = message;
        Status = status;
    }

    public Response(string message, ResponseData data)
    {
        Message = message;
        Status = ((int)HttpStatusCode.Accepted);
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData();
