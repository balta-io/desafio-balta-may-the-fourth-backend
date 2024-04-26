using May.The.Fourth.Backend.Data.Entities;

namespace May.The.Fourth.Backend.Services.Mappers
{
    public static class MapperDto
    {
        public static FilmeDto MapToFilmDto(FilmeEntity filme)
        {
            if (filme == null)
                return new FilmeDto();
            return new FilmeDto
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Episodio = filme.Episodio,
                TextoAbertura = filme.TextoAbertura,
                Diretor = filme.Diretor,
                Produtor = filme.Produtor,
                DataLancamento = filme.DataLancamento
            };
        }

        public static IList<FilmeDto> MapToFilmDto(IList<FilmeEntity> filmeEntities)
        {
            IList<FilmeDto> filmes = new List<FilmeDto>();
            if (filmeEntities.Any())
            {
                foreach (var filmeEntity in filmeEntities)
                    filmes.Add(MapToFilmDto(filmeEntity));
            }
            return filmes;
        }

        public static CharacterDto MapToCharacterDto(CharacterEntity character)
        {
            if (character == null)
                return new CharacterDto();
            return new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Height = character.Height,
                Weight = character.Weight,
                HairColor = character.HairColor,
                SkinColor = character.SkinColor,
                EyeColor = character.EyeColor,
                BirthYear = character.BirthYear,
                Gender = character.Gender,
                PlanetID = character.PlanetID
            };
        }

        public static IList<CharacterDto> MapToCharacterDto(IList<CharacterEntity> characterEntities)
        {
            IList<CharacterDto> characters = new List<CharacterDto>();
            if (characterEntities.Any())
            {
                foreach (var characterEntity in characterEntities)
                    characters.Add(MapToCharacterDto(characterEntity));
            }
            return characters;
        }                 
    }
}