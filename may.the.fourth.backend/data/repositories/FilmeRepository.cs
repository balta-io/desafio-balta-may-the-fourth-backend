using May.The.Fourth.Backend.Data.Contexts;
using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Data.Interfaces;

namespace May.The.Fourth.Backend.Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly StarWarsContext ctx;

        public FilmeRepository(StarWarsContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<FilmeEntity>> GetFilmes()
        {
            try
            {
                IQueryable<FilmeEntity> filmes = await Task.FromResult(ctx.Filmes);
                return filmes.ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"An error has occurred. Contact your admins and give them this reference: {e.StackTrace}");
            }
        }
    }
}