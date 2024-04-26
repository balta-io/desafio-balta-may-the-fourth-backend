using MayTheFourth.Data;
using MayTheFourth.Helpers.Validations;
using MayTheFourth.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Endpoints.Filme;

public static class FilmeEndpoints
{
    public static IResult GetFilme(
        [FromServices] MayTheFourthDataContext context,
        [FromServices] IFilmeService filmeService)
    {
        var filmes = filmeService.GetFilm(context);
        return Results.Ok(filmes);
    }

    public static IResult GetFilmeById(
        int idfilme,
        [FromServices] MayTheFourthDataContext context,
        [FromServices] IFilmeService filmeService)
    {
        var filmes = filmeService.GetFilmeById(idfilme, context);
        if (filmes != null)
            return Results.Ok(filmes);
        else
            return Results.NotFound("Conteúdo não encontrado!");
    }

    public static async Task<IResult> PostFilme([FromBody] Dtos.Filme model,
        [FromServices] MayTheFourthDataContext context,
        [FromServices] IFilmeService filmeService)
    {
        try
        {
            var errors = ValidateFilme.ValidateFilm(model);
            if (errors.Any())
                return Results.ValidationProblem(errors.ToDictionary(error => error, error => new string[] { error }));
            
            var filme = new Dtos.Filme()
            {
                Titulo = model.Titulo,
                Episodio = model.Episodio,
                Diretor = model.Diretor,
                Produtor = model.Produtor,
                DataLancamento = model.DataLancamento
            };

            await filmeService.SaveFilm(filme, context);
            return Results.Created($"/v1/filme/{filme.Id}", filme);
        }
        catch (DbUpdateException ex)
        {
            return Results.Problem(
                "Não foi possível cadastrar o aluno. Erro: " + ex.Message,
                statusCode: 500);
        }
        catch (Exception ex)
        {
            return Results.Problem(
                "Falha interna do servidor. Erro: " + ex.Message,
                statusCode: 500);
        }
    }
}