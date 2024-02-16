using AutoMapper;
using ecommerce_music_back.Models;

namespace ecommerce_music_back.data
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StringInstrument, StringInstrument>();
        }
    }
}