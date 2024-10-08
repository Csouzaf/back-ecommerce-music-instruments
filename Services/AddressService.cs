using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;

namespace ecommerce_music_back.Services
{
    public class AddressService : IAddressRepository
    {
        
        private readonly IMapper _mapper;
        
        private readonly IBrasilApiRepository _brasilApiRepository;

        public AddressService(IBrasilApiRepository brasilApiRepository, IMapper mapper)
        {
            _mapper = mapper;
            _brasilApiRepository = brasilApiRepository;
        }

        public async Task<GenericResponse<AddressResponse>> findAddresByCep(string cep)
        {
            var address = await _brasilApiRepository.findAddressByCep(cep);
            var response =  _mapper.Map<GenericResponse<AddressResponse>>(address);
            return response;
        }

    }
}