using AutoMapper;
using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DrumnsPercussionResponse, DrumnsPercussion>()
                .ReverseMap();
                

            CreateMap<Brand, BrandResponse>()
                .ReverseMap();


            CreateMap<StringInstrument, StringInstrumentResponse>()
                .ReverseMap();
            

            CreateMap<WindInstrument, WindInstrumentResponse>()
                .ReverseMap();


            CreateMap<Bank, BankResponse>()
                .ReverseMap();

            CreateMap<Address, AddressResponse>()
                .ReverseMap();

            CreateMap(typeof(GenericResponse<>), typeof(GenericResponse<>));
         
   
            
        }
    }
}