using AutoMapper;
using udemyTutorial.DTOs.Character;

namespace udemyTutorial
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
        }
    }
}
