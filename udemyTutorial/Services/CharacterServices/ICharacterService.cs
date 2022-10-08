using udemyTutorial.DTOs.Character;

namespace udemyTutorial.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> getAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> getCharacterById(string id);
        Task<ServiceResponse<AddCharacterDTO>> addCharacters(AddCharacterDTO addCharacterDTO);
        Task<ServiceResponse<GetCharacterDTO>> updateCharacter(UpdateCharacterDTO updateCharacterDto,string id);
        Task<ServiceResponse<GetCharacterDTO>> deleteCharacter(string id);

    }
}
