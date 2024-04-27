using System.Net;
using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchBySlug;

public class Response: SharedContext.UseCases.Response
{
    public Response(string message, int status)
    {
        Message = message;
        Status = status;
    }

    public Response(string message, ResponseData data)
    {
        Message = message;
        Status = (int)HttpStatusCode.OK;
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(Vehicle vehicle);