using MayTheFourth.Data;
using MayTheFourth.Dtos;

namespace MayTheFourth.Interfaces.Services;

public interface IFilmeService
{
    public Task SaveFilm(Filme filme, MayTheFourthDataContext context);

    public IList<Filme> GetFilm(MayTheFourthDataContext context);

    public Filme GetFilmeById(int idfilme, MayTheFourthDataContext context);
}