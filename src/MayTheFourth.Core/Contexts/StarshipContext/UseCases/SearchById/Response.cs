﻿using MayTheFourth.Core.Dtos;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchById;

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
        Status = 200;
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(StarshipDetailsDto starshipDetails);
