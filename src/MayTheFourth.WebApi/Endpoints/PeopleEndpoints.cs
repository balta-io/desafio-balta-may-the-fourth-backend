using MayTheFourth.Application.Features.People;
using MayTheFourth.Application.Features.People.GetPeople;
using MayTheFourth.Application.Features.People.GetPeopleById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class PeopleEndpoints
    {
        //TODO - Adicionar Endpoints
        public static void MapPeopleEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/people").WithTags("People").WithOpenApi();

            root.MapGet("/",GetPeopleAsync)
                .Produces<GetPeopleResponse>()
                .WithSummary("Obtem todos os personagens cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de personagens cadastrados");

            root.MapGet("/{id:int}",GetPeopleByIdAsync)
                .Produces<GetPeopleResponse>()
                .WithSummary("Obtem um personagem pelo Id")
                .WithDescription("Endpoint para leitura e retorno de um personagem cadastrado pelo Id correspondente");
        }

        //TODO - Adicionar métodos
        public static async Task<IResult> GetPeopleAsync( int page, int take, [FromServices] IMediator mediator,CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetPeopleRequest(), cancellationToken);

            var total = result.Count();
            result = result.Skip((page-1)* take).Take(take).ToList();

            return Results.Ok(new {total, CurrentPage = page,take,result});
        }

        public static async Task<IResult> GetPeopleByIdAsync([FromRoute] int id,[FromServices] IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetPeopleByIdRequest(id), cancellationToken);

            if(result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }
    }
}
