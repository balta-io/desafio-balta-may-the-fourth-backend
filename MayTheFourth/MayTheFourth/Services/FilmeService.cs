using MayTheFourth.Data;
using MayTheFourth.Dtos;
using MayTheFourth.Interfaces.Services;

namespace MayTheFourth.Services;

public class FilmeService : IFilmeService
{
    public async Task SaveFilm(Filme filme, MayTheFourthDataContext context)
    {
        await context.Filmes.AddAsync(filme);
        await context.SaveChangesAsync();
    }

    public IList<Filme> GetFilm(MayTheFourthDataContext context)
    {
        return context.Filmes.ToList();
    }
    
    public Filme GetFilmeById(int idfilme, MayTheFourthDataContext context)
    {
        return context.Filmes.FirstOrDefault(e => e.Id == idfilme);
    }
}