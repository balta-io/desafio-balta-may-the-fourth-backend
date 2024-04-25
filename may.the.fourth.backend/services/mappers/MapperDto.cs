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
    }
}