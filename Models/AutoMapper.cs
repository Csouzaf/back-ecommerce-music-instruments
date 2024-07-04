using AutoMapper;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DrumnsPercussionResponse, DrumnsPercussion>();
            CreateMap<DrumnsPercussion, DrumnsPercussionResponse>();

            CreateMap<Brand, BrandResponse>()
                .ReverseMap();

            CreateMap<StringInstrument, StringInstrumentResponse>()
                .ReverseMap();
            
        }
    }
}