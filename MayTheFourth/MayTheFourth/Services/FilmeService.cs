using MayTheFourth.Infra.Context;
using MayTheFourth.Interfaces.Services;

namespace MayTheFourth.Services;

/// <summary>
/// Fornece serviços para manipulação de dados de filmes, incluindo salvar, listar todos os filmes e buscar por ID.
/// </summary>
public class FilmeService : IFilmeService
{
    /// <summary>
    /// Salva um novo filme no banco de dados.
    /// </summary>
    /// <param name="filme">O filme a ser salvo.</param>
    /// <param name="context">O contexto do banco de dados através do qual o filme será salvo.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona de salvar o filme no banco de dados.</returns>
    public async Task SaveFilm(Filme filme, MayTheFourthDataContext context)
    {
        await context.Filmes.AddAsync(filme);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Recupera uma lista de todos os filmes no banco de dados.
    /// </summary>
    /// <param name="context">O contexto do banco de dados usado para recuperar os filmes.</param>
    /// <returns>Uma lista contendo todos os filmes.</returns>
    public IList<Filme> GetFilm(MayTheFourthDataContext context)
    {
        return context.Filmes.ToList();  
    } 
    
    /// <summary>
    /// Busca um filme por seu identificador único.
    /// </summary>
    /// <param name="idfilme">O identificador único do filme a ser buscado.</param>
    /// <param name="context">O contexto do banco de dados usado para buscar o filme.</param>
    /// <returns>O filme correspondente ao ID fornecido ou null se nenhum filme for encontrado.</returns>
    public Filme GetFilmeById(int idfilme, MayTheFourthDataContext context)
    {
        return context.Filmes.FirstOrDefault(e => e.Id == idfilme);
    }
}