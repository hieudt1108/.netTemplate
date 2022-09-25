using Microsoft.AspNetCore.Mvc;
using udemyTutorial.DTOs.Character;
using udemyTutorial.Services.CharacterServices;

namespace udemyTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> getAll()
        {
            return Ok(await _characterService.getAllCharacters());
        }

        [HttpGet("getOne/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> getOne(string id)
        {
            return Ok(await _characterService.getCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AddCharacterDTO>>> addCharacter(
        [FromBody] AddCharacterDTO addCharacterDTO)
        {
            return Ok(await _characterService.addCharacters(addCharacterDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> updateCharacter(
        [FromBody] UpdateCharacterDTO updateCharacterDto, string id)
        {
            return Ok(await _characterService.updateCharacter(updateCharacterDto, id));
        }
    }
}
