using MayTheFourth.Data;
using MayTheFourth.Dtos;

namespace MayTheFourth.Interfaces.Services;

/// <summary>
/// Interface para FilmeService.
/// </summary>
public interface IFilmeService
{
    /// <summary>
    /// Salva um novo filme no banco de dados.
    /// </summary>
    /// <param name="filme">O filme a ser salvo.</param>
    /// <param name="context">O contexto do banco de dados através do qual o filme será salvo.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona de salvar o filme no banco de dados.</returns>
    public Task SaveFilm(Filme filme, MayTheFourthDataContext context);

    /// <summary>
    /// Recupera uma lista de todos os filmes no banco de dados.
    /// </summary>
    /// <param name="context">O contexto do banco de dados usado para recuperar os filmes.</param>
    /// <returns>Uma lista contendo todos os filmes.</returns>
    public IList<Filme> GetFilm(MayTheFourthDataContext context);

    /// <summary>
    /// Busca um filme por seu identificador único.
    /// </summary>
    /// <param name="idfilme">O identificador único do filme a ser buscado.</param>
    /// <param name="context">O contexto do banco de dados usado para buscar o filme.</param>
    /// <returns>O filme correspondente ao ID fornecido ou null se nenhum filme for encontrado.</returns>
    public Filme GetFilmeById(int idfilme, MayTheFourthDataContext context);
}