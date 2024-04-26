using MayTheFourth.Data;
using MayTheFourth.Helpers.Validations;
using MayTheFourth.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Endpoints.Filme;

/// <summary>
/// Define os endpoints relacionados à gestão de filmes, incluindo obtenção e criação de registros de filmes.
/// </summary>
public static class FilmeEndpoints
{
    /// <summary>
    /// Obtém uma lista de todos os filmes.
    /// </summary>
    /// <param name="context">O contexto do banco de dados para acesso aos dados.</param>
    /// <param name="filmeService">O serviço que fornece operações de negócio relacionadas a filmes.</param>
    /// <returns>Uma lista de filmes encapsulada em um resultado HTTP.</returns>
    public static IResult GetFilme(
        [FromServices] MayTheFourthDataContext context,
        [FromServices] IFilmeService filmeService)
    {
        var filmes = filmeService.GetFilm(context);
        return Results.Ok(filmes);
    }

    /// <summary>
    /// Obtém um filme pelo seu identificador único.
    /// </summary>
    /// <param name="idfilme">O identificador único do filme.</param>
    /// <param name="context">O contexto do banco de dados para acesso aos dados.</param>
    /// <param name="filmeService">O serviço que fornece operações de negócio relacionadas a filmes.</param>
    /// <returns>Um resultado HTTP contendo o filme solicitado ou um status de não encontrado.</returns>
    public static IResult GetFilmeById(
        int idfilme,
        [FromServices] MayTheFourthDataContext context,
        [FromServices] IFilmeService filmeService)
    {
        var filmes = filmeService.GetFilmeById(idfilme, context);
        if (filmes != null)
            return Results.Ok(filmes);

        return Results.NotFound("Conteúdo não encontrado!");
    }

    /// <summary>
    /// Cria um novo filme com base nos dados fornecidos e o salva no banco de dados.
    /// </summary>
    /// <param name="model">O DTO do filme a ser criado.</param>
    /// <param name="context">O contexto do banco de dados para acesso aos dados.</param>
    /// <param name="filmeService">O serviço que fornece operações de negócio relacionadas a filmes.</param>
    /// <returns>Um resultado HTTP indicando sucesso ou falha na criação do filme.</returns>
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