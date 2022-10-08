using AutoMapper;
using Microsoft.EntityFrameworkCore;
using udemyTutorial.Data;
using udemyTutorial.DTOs.Character;

namespace udemyTutorial.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        private static List<Character> characters = new List<Character>
        {
            new Character
            {
                Name = "hieu",
                Id = "1",
            }
        };

        public async Task<ServiceResponse<List<GetCharacterDTO>>> getAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> getCharacterById(string id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var dbCharacter = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<AddCharacterDTO>> addCharacters(AddCharacterDTO addCharacterDTO)
        {
            Guid g = Guid.NewGuid();
            Character character = _mapper.Map<Character>(addCharacterDTO);
            character.Id = g.ToString();
            _dataContext.Characters.Add(character);
            await _dataContext.SaveChangesAsync();
            var serviceResponse = new ServiceResponse<AddCharacterDTO>();
            serviceResponse.Data = addCharacterDTO;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> updateCharacter(UpdateCharacterDTO updateCharacterDto,
        string id)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();
            Character character = characters.FirstOrDefault(c => c.Id == id);
            _mapper.Map(updateCharacterDto, character);

            response.Data = _mapper.Map<GetCharacterDTO>(character);
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> deleteCharacter(string id)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();
            Character character = characters.FirstOrDefault(c => c.Id == id);
            characters.Remove(character);
            response.Data = _mapper.Map<GetCharacterDTO>(character);
            return response;
        }
    }
}
