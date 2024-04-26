using May.The.Fourth.Backend.Data.Interfaces;
using May.The.Fourth.Backend.Services.Interfaces;
using May.The.Fourth.Backend.Services.Mappers;
using May.The.Fourth.Backend.Services.Messages;

namespace May.The.Fourth.Backend.Services
{
    public class CharacterService: ICharacterService
    {
        private readonly ICharacterRepository characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
        }

        public async Task<CharacterListResponse> GetCharacters()
        {
            try
            {
                CharacterListResponse characterListResponse = new CharacterListResponse();
                var characters = await characterRepository.GetCharacters();
                if (characters.Any())
                {
                    characterListResponse.Success = true;
                    characterListResponse.Message = "SUCCESS";
                    characterListResponse.StatusCode = 200;
                    characterListResponse.CharacterDto = May.The.Fourth.Backend.Services.Mappers.MapperDto.MapToCharacterDto(characters);                                        
                }
                else
                {
                    characterListResponse.Success = false;
                    characterListResponse.Message = "FAILED";
                    characterListResponse.StatusCode = 500;
                    characterListResponse.CharacterDto = null;
                }
                return characterListResponse;
            }
            catch(Exception)
            {
                return new CharacterListResponse
                {
                    Success = false,
                    Message = "Internal server error",
                    StatusCode = 500,
                    CharacterDto = null
                };
            }
        }
    }
}