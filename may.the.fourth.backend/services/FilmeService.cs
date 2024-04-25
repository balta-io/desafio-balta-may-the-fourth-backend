using May.The.Fourth.Backend.Data.Interfaces;
using May.The.Fourth.Backend.Services.Interfaces;
using May.The.Fourth.Backend.Services.Mappers;
using May.The.Fourth.Backend.Services.Messages;

namespace May.The.Fourth.Backend.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            this.filmeRepository = filmeRepository;
        }

        public async Task<FilmeListResponse> GetFilmes()
        {
            try
            {
                FilmeListResponse filmeListResponse = new FilmeListResponse();
                var filmes = await filmeRepository.GetFilmes();
                if (filmes.Any())
                {
                    filmeListResponse.Success = true;
                    filmeListResponse.Message = "SUCCESS";
                    filmeListResponse.StatusCode = 200;
                    filmeListResponse.FilmeDto = MapperDto.MapToFilmDto(filmes);
                }
                else
                {
                    filmeListResponse.Success = false;
                    filmeListResponse.Message = "FAILED";
                    filmeListResponse.StatusCode = 500;
                    filmeListResponse.FilmeDto = null;
                }
                return filmeListResponse;
            }
            catch(Exception)
            {
                return new FilmeListResponse
                {
                    Success = false,
                    Message = "Internal server error",
                    StatusCode = 500,
                    FilmeDto = null
                };
            }
        }
    }  
}