using AutoMapper;
using labworkData;
using labworkWebApi.Models.Game;

namespace labworkWebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameAddDto, Game>();
            CreateMap<Game, GameGetDto>()
                .ForMember(dest => dest.FullCompany,
                    opt => opt.MapFrom(src => $"{src.Developer} | {src.Publisher}"));

            //.ForMember(dest => dest.Category,
            //    opt => opt.Ignore())
        }
    }
}
