using May.The.Fourth.Backend.Data.Contexts;
using May.The.Fourth.Backend.Data.Entities;
using May.The.Fourth.Backend.Data.Interfaces;

namespace May.The.Fourth.Backend.Data.Repositories
{
    public class CharacterRepository:ICharacterRepository
    {
        private readonly StarWarsContext ctx;

        public CharacterRepository(StarWarsContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<CharacterEntity>> GetCharacters()
        {
            try
            {
                IQueryable<CharacterEntity> characters = await Task.FromResult(ctx.Characters);
                return characters.ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"An error has occurred. Contact your admins and give them this reference: {e.StackTrace}");
            }
        }
    }
}