using AutoMapper;
using udemyTutorial.DTOs.Character;

namespace udemyTutorial.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
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
            return new ServiceResponse<List<GetCharacterDTO>>
            {
                Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetCharacterDTO>> getCharacterById(string id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<AddCharacterDTO>> addCharacters(AddCharacterDTO addCharacterDTO)
        {
            Guid g = Guid.NewGuid();
            Character character = _mapper.Map<Character>(addCharacterDTO);
            character.Id = g.ToString();
            characters.Add(character);
            var serviceResponse = new ServiceResponse<AddCharacterDTO>();
            serviceResponse.Data = addCharacterDTO;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> updateCharacter(UpdateCharacterDTO updateCharacterDto, string id)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();
            Character character = characters.FirstOrDefault(c => c.Id == id);
            character.Name = updateCharacterDto.Name;
            character.HitPoints = updateCharacterDto.HitPoints;
            character.Strength = updateCharacterDto.Strength;
            character.Defense = updateCharacterDto.Defense;
            character.Intelligence = updateCharacterDto.Intelligence;
            character.Class = updateCharacterDto.Class;

            response.Data = _mapper.Map<GetCharacterDTO>(character);
            return response;
        }
    }
}
